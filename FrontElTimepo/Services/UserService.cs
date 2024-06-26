using FrontElTimepo.Models;
using System.Net.Http.Json;

namespace FrontElTimepo.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UsuariosDto>> GetUsersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<UsuariosDto>>("api/Users");
        }

        public async Task<UsuariosDto> GetUsersByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<UsuariosDto>($"api/Users/{id}");
        }

        public async Task CreateUsersAsync(UsuariosDto users)
        {
            await _httpClient.PostAsJsonAsync("api/Users", users);
        }

        public async Task UpdateUsersAsync(UsuariosDto users)
        {
            await _httpClient.PutAsJsonAsync($"api/Users/{users.UserId}", users);
        }

        public async Task DeleteUsersAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Users/{id}");
        }
    }
}
