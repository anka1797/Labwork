using labworkWebApp.Models.Game;
using labworkWebApp.Models.GameGenre;
using System.Text.Json;

namespace labworkWebApp.Services
{
    public class GameApiService
    {
        private JsonSerializerOptions _jsonSerializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            //PropertyNameCaseInsensitive = true,    вообще отключаем надобность регистра
        };
        private HttpClient _httpClient;
        //private string _host = "http://localhost:5272";
        public GameApiService(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("GameApi");
        }
        public async Task<List<GameDto>?> GetGame(GameFilterDto filter) //Вывод таблицы
        {
            var response = await _httpClient.PostAsJsonAsync("/Game/GetAll", filter);
            var responseData = await GetResponseData<List<GameDto>>(response);

            return responseData;
        }

        public async Task<List<GenreDto>> GetGenres()
        {
            var response = await _httpClient.GetAsync("/GameGenre/GetAll");
            var responseData = await GetResponseData<List<GenreDto>>(response);

            return responseData;
        }

        public async Task<bool> AddGame(GameAddDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync("/Game/Add", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteGame(int id)
        {
            var response = await _httpClient.DeleteAsync($"/Game/Delete/?id={id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<GameDto?> GetGame(int id) //достаем нужную строку
        {
            var response = await _httpClient.GetAsync($"/Game/Get?id={id}");
            var responseData = await GetResponseData<GameDto>(response);
            return responseData;
        }

        private async Task<T?> GetResponseData<T> (HttpResponseMessage httpResponse)
        {
            var responseText = await httpResponse.Content.ReadAsStringAsync();
            var responseData = JsonSerializer.Deserialize<T>(responseText, _jsonSerializerOptions);

            return responseData;
        }

        public async Task<bool> EditGame(GameEditDto dto) //изменяем
        {
            var response = await _httpClient.PostAsJsonAsync("/Game/Edit", dto);
            return response.IsSuccessStatusCode;
        }
    }
   
}
