using labworkWebApp.Models;
using labworkWebApp.Models.Game;
using labworkWebApp.Models.GameViewModel;
using labworkWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace labworkWebApp.Controllers
{
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;
        private readonly GameApiService _gameApiService;
        public GameController(ILogger<GameController> logger, GameApiService gameApiService)
        {
            _logger = logger;
            _gameApiService = gameApiService;
        }

        #region -- Вывод всего списка с фильтрами
        [HttpGet]
        public async Task<IActionResult> Index() //Вывод таблицы
        {
            var viewModel = new GameViewModel
            {
                Games = await _gameApiService.GetGame(new GameFilterDto()),
                Genres = await _gameApiService.GetGenres()
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(GameFilterDto filter) //Вывод таблицы
        {
            
            var viewModel = new GameViewModel
            {
                Games = await _gameApiService.GetGame(filter),
                Genres = await _gameApiService.GetGenres()
            };
            return View(viewModel);
        }
        #endregion
        


        #region -- Добавление

        [HttpPost]
        public async Task<IActionResult> Add(GameAddDto dto)
        {
            var viewModel = new GameAddViewModel()
            {
                Genres = await _gameApiService.GetGenres(),
                Game = dto
            };
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var result = await _gameApiService.AddGame(dto);

            if (!result)
            {
                ModelState.AddModelError("api_erorr", "Ошибка валидации данных");
                return View(viewModel);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {

            var viewModel = new GameAddViewModel()
            {
                Genres = await _gameApiService.GetGenres()
            };
            return View(viewModel);

        }
        #endregion

        #region -- Удаление
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _gameApiService.DeleteGame(id);
            
            TempData["Message"] = result ? "Игра удалена успешно" : "Ошибка удаления";
            
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region -- редактирование
        [HttpPost]
        public async Task<IActionResult> Edit(GameEditDto dto) //изменяем
        {
            var viewModel = new GameEditViewModel()
            {
                Genres = await _gameApiService.GetGenres()
                //Game = responseData
            };
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var result = await _gameApiService.EditGame(dto);
            if (!result)
            {
                ModelState.AddModelError("api_erorr", "Ошибка валидации данных");
                return View(dto);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id) //достаем нужную строку
        {
            var viewModel = new GameEditViewModel()
            {
                Genres = await _gameApiService.GetGenres(),
                Game = await _gameApiService.GetGame(id),
        };
            return View(viewModel);
        }
        #endregion

        #region -- ненужная инфа
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}
