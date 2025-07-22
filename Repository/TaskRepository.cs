using Api.Interfaces;
using Api.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Api.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly string _apiKey;

        public TaskRepository(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _baseUrl = configuration["baseUrl"]!;
            _apiKey = configuration["apiKey"]!;
        }

        public async Task<Tasks> CreateTask(Tasks task)
        {
            var url = $"{_baseUrl}/rest/v1/TASK";

            var json = JsonSerializer.Serialize(task);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = content
            };

            request.Headers.Add("apikey", _apiKey);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
            request.Headers.Add("Prefer", "return=representation");

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var errorBody = await response.Content.ReadAsStringAsync();
                throw new Exception($"Supabase insert failed: {response.StatusCode} - {errorBody}");
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<Tasks>>(responseBody);

            return result!.First();
        }

        public async Task<string> DeleteTask(int id)
        {
            var url = $"{_baseUrl}/rest/v1/TASK?id=eq.{id}";

            var request = new HttpRequestMessage(HttpMethod.Delete, url);

            request.Headers.Add("apikey", _apiKey);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var errorBody = await response.Content.ReadAsStringAsync();
                throw new Exception($"Supabase delete failed: {response.StatusCode} - {errorBody}");
            }

            return $"Se ha borrado la tarea ID: {id.ToString()}";
        }

        public async Task<Tasks> UpdateTask(Tasks task)
        {
            var url = $"{_baseUrl}/rest/v1/TASK?id=eq.{task.id}";

            var json = JsonSerializer.Serialize(task);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Put, url)
            {
                Content = content
            };

            request.Headers.Add("apikey", _apiKey);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
            request.Headers.Add("Prefer", "return=representation");

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var errorBody = await response.Content.ReadAsStringAsync();
                throw new Exception($"Supabase insert failed: {response.StatusCode} - {errorBody}");
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<Tasks>>(responseBody);

            return result!.First();
        }
    }
}
