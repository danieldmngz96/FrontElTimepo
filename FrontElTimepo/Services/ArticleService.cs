using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using FrontElTimepo.Models;

namespace BlazorApp.Services
{
    public class ArticleService
    {
        private readonly HttpClient _httpClient;

        public ArticleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ArticleDto>> GetArticlesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ArticleDto>>("api/articles");
        }

        public async Task<ArticleDto> GetArticleByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ArticleDto>($"api/articles/{id}");
        }

        public async Task CreateArticleAsync(ArticleDto article)
        {
            await _httpClient.PostAsJsonAsync("api/articles", article);
        }

        public async Task UpdateArticleAsync(ArticleDto article)
        {
            await _httpClient.PutAsJsonAsync($"api/articles/{article.Id}", article);
        }

        public async Task DeleteArticleAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/articles/{id}");
        }
    }
}

