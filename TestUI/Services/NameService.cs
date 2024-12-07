using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using Test2UI.Models;

namespace Test2UI.Services
{
    public class NameService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public NameService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration.GetSection("WebAPI:BaseUrl").Value;
        }

        public async Task<List<NameModel>> GetAllNamesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<NameModel>>($"{_baseUrl}Name");
        }

        public async Task<NameModel> GetNameByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<NameModel>($"{_baseUrl}Name/{id}");
        }

        public async Task AddNameAsync(NameModel name)
        {
            await _httpClient.PostAsJsonAsync($"{_baseUrl}Name", name);
        }

        public async Task UpdateNameAsync(int id, NameModel name)
        {
            await _httpClient.PutAsJsonAsync($"{_baseUrl}Name/{id}", name);
        }

        public async Task DeleteNameAsync(int id)
        {
            await _httpClient.DeleteAsync($"{_baseUrl}Name/{id}");
        }
    }
}
