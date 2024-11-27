using labworkData;
using Microsoft.AspNetCore.Mvc;

namespace labworkWebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GameGenreController : ControllerBase
    {
        private readonly ILogger<GameGenreController> _logger;
        private readonly GameContext _context;
        public GameGenreController(ILogger<GameGenreController> logger, GameContext context)
        {
            _logger = logger;
            _context = context;
        }
        //добавление в базу
        [HttpPut]
        public GameGenre Put([FromBody] GameGenre model)
        {
            _context.GameGenres.Add(model);
            _context.SaveChanges();
            return model;
        }

        //Получение строки через id
        [HttpGet]
        public GameGenre? Get(int id)
        {
            var genre = _context.GameGenres.FirstOrDefault(x => x.Id == id);

            return genre;
        }
        //получение всех строк
        [HttpGet]
        public List<GameGenre> GetAll()
        {
            var genre = _context.GameGenres.ToList();

            return genre;
        }

        //Удаление строки
        [HttpDelete]
        public void Delete(int id)
        {
            var genre = _context.GameGenres.FirstOrDefault(x => x.Id == id);
            if (genre != null)
            {
                _context.GameGenres.Remove(genre);
                _context.SaveChanges();
            }
        }

        //Редакирование студента
        [HttpPost]
        public GameGenre? Post([FromBody] GameGenre model)
        {
            var genre = _context.GameGenres.FirstOrDefault(x => x.Id == model.Id);
            if (genre != null)
            {
                genre.Name = model.Name;

                _context.GameGenres.Update(genre);
                _context.SaveChanges();
            }
            return genre;
        }
    }
}
