using Bioplace.Application.Interfaces;
using BioPlace.Domain.Entities;
using BioPlace.Domain.Entities.Devices;
using System.Net.Http.Json;


namespace BioPlace.Infrastructure.Services
{
    public class AuroralService : IAuroralService
    {
        private readonly HttpClient _httpClient;

        public AuroralService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Device>> GetDevicesAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Device>>("devices")
                   ?? Enumerable.Empty<Device>();
        }

        public async Task<Device?> GetDeviceByIdAsync(string deviceId)
        {
            return await _httpClient.GetFromJsonAsync<Device>($"devices/{deviceId}");
        }

        public async Task<bool> SendDataToDeviceAsync(string deviceId, object data)
        {
            var response = await _httpClient.PostAsJsonAsync($"devices/{deviceId}/data", data);
            return response.IsSuccessStatusCode;
        }

    }
}