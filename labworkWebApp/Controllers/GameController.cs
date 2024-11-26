using labworkWebApp.Models;
using labworkWebApp.Models.Game;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace labworkWebApp.Controllers
{
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;
        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> Index() //Вывод таблицы
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("http://localhost:5272/Game/GetAll");
            var responseText = await response.Content.ReadAsStringAsync();

            var responseData = JsonSerializer.Deserialize<List<GameDto>>(responseText, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                //PropertyNameCaseInsensitive = true,    вообще отключаем надобность регистра
            });
            
            return View(responseData);
        }

        [HttpPost]
        public async Task<IActionResult> Add(GameAddDto dto) //Вывод таблицы
        {

            return View();
        }

        [HttpGet]
        public IActionResult Add() //Вывод таблицы
        {
            

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
