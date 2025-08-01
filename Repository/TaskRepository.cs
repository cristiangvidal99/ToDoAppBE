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
        public TaskRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Tasks>> GetAllTasks()
        {
            var url = "rest/v1/TASK";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Prefer", "return=representation");

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var errorBody = await response.Content.ReadAsStringAsync();
                throw new Exception($"Supabase insert failed: {response.StatusCode} - {errorBody}");
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<Tasks>>(responseBody);

            return result!; 
        }

        public async Task<Tasks> GetTaskById(int task)
        {
            var url = "rest/v1/TASK";

            var json = JsonSerializer.Serialize(task);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Get, url)
            {
                Content = content
            };

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

        public async Task<CreateTask> CreateTask(CreateTask task)
        {
            var url = "rest/v1/TASK";

            var json = JsonSerializer.Serialize(task);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = content
            };

            request.Headers.Add("Prefer", "return=representation");

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var errorBody = await response.Content.ReadAsStringAsync();
                throw new Exception($"Supabase insert failed: {response.StatusCode} - {errorBody}");
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<CreateTask>>(responseBody);

            return result!.First();
        }


        public async Task<string> DeleteTask(int id)
        {
            var url = $"rest/v1/TASK?id=eq.{id}";
            var request = new HttpRequestMessage(HttpMethod.Delete, url);

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var errorBody = await response.Content.ReadAsStringAsync();
                throw new Exception($"Supabase delete failed: {response.StatusCode} - {errorBody}");
            }

            return "OK";
        }

        public async Task<Tasks> UpdateTask(Tasks task)
        {
            var url = $"rest/v1/TASK?id=eq.{task.id}";

            var json = JsonSerializer.Serialize(task);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Put, url)
            {
                Content = content
            };

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
