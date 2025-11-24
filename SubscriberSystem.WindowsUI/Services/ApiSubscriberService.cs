using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using SubscriberSystem.WindowsUI.Models;

namespace SubscriberSystem.WindowsUI.Services
{
    public class ApiSubscriberService
    {
        private readonly HttpClient _httpClient;

        // "https://localhost:7025/"
        public ApiSubscriberService(string baseAddress)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };
        }

        // GET: all subscribers
        public async Task<List<SubscriberDto>> GetAllSubscribersAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<SubscriberDto>>(
                "api/subscribers"
            );

            return response ?? new List<SubscriberDto>();
        }

        // GET: subscriber by id
        public async Task<SubscriberDto?> GetSubscriberByIdAsync(int subscriberId)
        {
            return await _httpClient.GetFromJsonAsync<SubscriberDto>(
                $"api/subscribers/{subscriberId}"
            );
        }

        // POST: create subscriber
        public async Task<SubscriberDto?> CreateSubscriberAsync(SubscriberDto subscriber)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "api/subscribers",
                subscriber
            );

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<SubscriberDto>();
        }

        // PUT: update subscriber
        public async Task<bool> UpdateSubscriberAsync(SubscriberDto subscriber)
        {
            if (subscriber.SubscriberId <= 0)
                throw new ArgumentException("SubscriberId must be set for update.");

            var response = await _httpClient.PutAsJsonAsync(
                $"api/subscribers/{subscriber.SubscriberId}",
                subscriber
            );

            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }

        // DELETE: delete subscriber
        public async Task<bool> DeleteSubscriberAsync(int subscriberId)
        {
            var response = await _httpClient.DeleteAsync(
                $"api/subscribers/{subscriberId}"
            );

            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }
    }
}
