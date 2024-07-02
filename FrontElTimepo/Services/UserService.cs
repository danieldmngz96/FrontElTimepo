using FrontElTimepo.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

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

        public async Task<UsuariosDto> GetUserByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<UsuariosDto>($"api/Users/{id}");
        }

        public async Task CreateUserAsync(UsuariosDto user)
        {
            await _httpClient.PostAsJsonAsync("api/Users", user);
        }

        public async Task UpdateUserAsync(UsuariosDto user)
        {
            await _httpClient.PutAsJsonAsync($"api/Users/{user.UserId}", user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Users/{id}");
        }
        public async Task<List<string>> GetRolesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<string>>("api/roles"); // Ajusta la ruta según tu API
        }

        // Método para asignar roles a un usuario
        public async Task AssignRolesAsync(int userId, List<int> roleIds)
        {
            // Realiza una solicitud HTTP POST para asignar roles al usuario
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"api/users/{userId}/roles", roleIds);

            // Maneja la respuesta como sea necesario (p. ej., verificar si fue exitosa)
            response.EnsureSuccessStatusCode();
        }
    }
}
