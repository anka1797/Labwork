using labworkWebApp.Models;
using labworkWebApp.Models.Game;
using labworkWebApp.Models.GameGenre;
using labworkWebApp.Models.GameViewModel;
using labworkWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

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

        #region -- ����� ����� ������ � ���������
        [HttpGet]
        public async Task<IActionResult> Index() //����� �������
        {
            var viewModel = new GameViewModel
            {
                Games = await _gameApiService.GetGame(new GameFilterDto()),
                Genres = await _gameApiService.GetGenres()
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(GameFilterDto filter) //����� �������
        {
            
            var viewModel = new GameViewModel
            {
                Games = await _gameApiService.GetGame(filter),
                Genres = await _gameApiService.GetGenres()
            };
            return View(viewModel);
        }
        #endregion
        


        #region -- ����������

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
            var httpClient = new HttpClient();
            var response = await httpClient.PutAsJsonAsync("http://localhost:5272/Game/Add", dto);
            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("api_erorr", "������ ��������� ������");
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

        #region -- ��������
        public async Task<IActionResult> Delete(int id)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.DeleteAsync($"http://localhost:5272/Game/Delete/?id={id}");

            if (!response.IsSuccessStatusCode)
            {
                //�������� �� �������
            }
            TempData["Message"] = "���� ������� �������";
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region -- ��������������
        [HttpPost]
        public async Task<IActionResult> Edit(GameEditDto dto) //��������
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
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync("http://localhost:5272/Game/Edit", dto);
            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("api_erorr", "������ ��������� ������");
                return View(dto);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id) //������� ������ ������
        {
            
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"http://localhost:5272/Game/Get?id={id}");
            var responseText = await response.Content.ReadAsStringAsync();

            var responseData = JsonSerializer.Deserialize<GameDto>(responseText, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                //PropertyNameCaseInsensitive = true,    ������ ��������� ���������� ��������
            });
            var viewModel = new GameEditViewModel()
            {
                Genres = await _gameApiService.GetGenres(),
                Game = responseData
            };
            return View(viewModel);
        }
        #endregion

        #region -- �������� ����
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
