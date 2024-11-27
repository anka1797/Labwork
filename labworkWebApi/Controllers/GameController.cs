using AutoMapper;
using AutoMapper.QueryableExtensions;
using labworkData;
using labworkWebApi.Configuration;
using labworkWebApi.Models;
using labworkWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace labworkWebApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class GameController(ILogger<GameController> _logger,
        GameContext _context,
        IMapper _mapper,
        SingletonService _singletonService,
        IOptions<MailConfig> _mailopthions) : ControllerBase
{
    [HttpGet]
    public string Test()
    {
        //отправляем почту из конфига
        var mail = _mailopthions;
        _singletonService.UserVisits.Add(DateTime.Now);
        //если время обращения больше 10 секунд, то он убирается из количества пользователей (количество вызовов по сути)
        _singletonService.UserVisits = _singletonService.UserVisits.Where(x => x >= DateTime.Now.AddSeconds(-10)).ToList();
        //_transient2Service.Counter++;
        //_singletonService.Counter++; //можно использовать как счетчик 
        //_scopedService.Counter++;
        //_transientService.Counter++;

        //return $"Количество обращений к singleton {_singletonService.Counter} к scoped {_scopedService.Counter}" +
        //$" к transient {_transientService.Counter}";
        return $"Количество пользователей онлайн {_singletonService.UserVisits.Count}";
    }



    //добавление в базу
    [HttpPut]
    public Game Add([FromBody] GameAddDto model)
    {
        var game = _mapper.Map<Game>(model);
        _context.Games.Add(game);
        _context.SaveChanges();
        return game;
    }

    //Получение строки через id
    [HttpGet]
    public GameGetDto? Get(int id)
    {
        var game = _context.Games
            .Include(p => p.Genre)
            .ProjectTo<GameGetDto>(_mapper.ConfigurationProvider)
            .FirstOrDefault(x => x.Id == id);

        return game;
    }
    //получение всех строк
    [HttpGet]
    public List<GameGetDto> GetAll()
    {
        var games = _context.Games
            .Include(p => p.Genre)
            .ProjectTo<GameGetDto>(_mapper.ConfigurationProvider)
            .ToList();

        //var gameDto = games.Select(x => new GameGetDto
        //{
        //    Id = x.Id,
        //    Name = x.Name,
        //    Developer = x.Developer,
        //    Publisher = x.Publisher,
        //    Category = x.Category,
        //    Genre = x.Genre.Name,
        //}).ToList();

        return games;
    }

    //Удаление строки
    [HttpDelete]
    public void Delete(int id)
    {
        var game = _context.Games.FirstOrDefault(x => x.Id == id);
        if (game != null)
        {
            _context.Games.Remove(game);
            _context.SaveChanges();
        }
    }

    //Редакирование 
    [HttpPost]
    public Game? Edit([FromBody] Game model)
    {
        var game = _context.Games.FirstOrDefault(x => x.Id == model.Id);
        if (game != null)
        {
            game.Name = model.Name;
            game.Developer = model.Developer;
            game.Publisher = model.Publisher;
            game.GenreId = model.GenreId;
            game.Access = model.Access;
            game.Category = model.Category;

            _context.Games.Update(game);
            _context.SaveChanges();
        }
        return game;
    }
}
