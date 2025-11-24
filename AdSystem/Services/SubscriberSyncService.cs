using AdSystem.Models;
using System.Net.Http.Json;
using System.Net;
public class SubscriberSyncService
{
    private readonly HttpClient _http;

    public SubscriberSyncService(HttpClient http)
    {
        _http = http;
        _http.BaseAddress = new Uri("https://localhost:7025/"); // subscriber system
    }

    public async Task<bool> UpdateSubscriberAsync(SubscriberUpdateDto dto)
    {
        var response = await _http.PutAsJsonAsync($"api/subscribers/{dto.SubscriberId}", dto);
        return response.IsSuccessStatusCode;
    }

    // Check if subscriber exists by ID 200 OK
    public async Task<bool> SubscriberExistsAsync(int subscriberId)
    {
        var response = await _http.GetAsync($"api/subscribers/{subscriberId}");
        return response.StatusCode == HttpStatusCode.OK;
    }
}

