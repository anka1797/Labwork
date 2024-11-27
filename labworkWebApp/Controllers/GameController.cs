using labworkWebApp.Models;
using labworkWebApp.Models.Game;
using labworkWebApp.Models.GameGenre;
using labworkWebApp.Models.GameViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace labworkWebApp.Controllers
{
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;
        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }
        #region -- ����� ����� ������
        public async Task<IActionResult> Index() //����� �������
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("http://localhost:5272/Game/GetAll");
            var responseText = await response.Content.ReadAsStringAsync();

            var responseData = JsonSerializer.Deserialize<List<GameDto>>(responseText, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                //PropertyNameCaseInsensitive = true,    ������ ��������� ���������� ��������
            });

            return View(responseData);
        }
        #endregion
        private async Task<List<GenreDto>> GetGenres()
        {

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("http://localhost:5272/GameGenre/GetAll");
            var responseText = await response.Content.ReadAsStringAsync();

            var responseData = JsonSerializer.Deserialize<List<GenreDto>>(responseText, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                //PropertyNameCaseInsensitive = true,    ������ ��������� ���������� ��������
            });

            return responseData;

        }


        #region -- ����������

        [HttpPost]
        public async Task<IActionResult> Add(GameAddDto dto)
        {
            var viewModel = new GameAddViewModel()
            {
                Genres = await GetGenres(),
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
                Genres = await GetGenres()
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
                Genres = await GetGenres()
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
                Genres = await GetGenres(),
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
