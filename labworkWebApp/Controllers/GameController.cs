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

        [HttpPost]
        public async Task<IActionResult> Add(GameAddDto dto) //����� �������
        {

            return View();
        }

        [HttpGet]
        public IActionResult Add() //����� �������
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
