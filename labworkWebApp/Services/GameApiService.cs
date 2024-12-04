using labworkWebApp.Models.Game;
using labworkWebApp.Models.GameGenre;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace labworkWebApp.Services
{
    public class GameApiService
    {
        public async Task<List<GameDto>?> GetGame(GameFilterDto filter) //Вывод таблицы
        {
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync("http://localhost:5272/Game/GetAll", filter);
            var responseText = await response.Content.ReadAsStringAsync();

            var responseData = JsonSerializer.Deserialize<List<GameDto>>(responseText, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                //PropertyNameCaseInsensitive = true,    вообще отключаем надобность регистра
            });

            return responseData;
        }

        public async Task<List<GenreDto>> GetGenres()
        {

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("http://localhost:5272/GameGenre/GetAll");
            var responseText = await response.Content.ReadAsStringAsync();

            var responseData = JsonSerializer.Deserialize<List<GenreDto>>(responseText, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                //PropertyNameCaseInsensitive = true,    вообще отключаем надобность регистра
            });

            return responseData;
        }
    }
   
}
