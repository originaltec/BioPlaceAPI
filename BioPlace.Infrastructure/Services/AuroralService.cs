using Bioplace.Application.Interfaces;
using BioPlace.Domain.Entities;
using BioPlace.Domain.Entities.Devices;
using System.Net.Http.Json;

namespace BioPlace.Infrastructure.Services
{
    // AuroralService is responsible for interacting with external services related to devices
    public class AuroralService : IAuroralService
    {
        private readonly HttpClient _httpClient; // The HttpClient is used to make HTTP requests to external services

        // Constructor that initializes the HttpClient instance
        public AuroralService(HttpClient httpClient)
        {
            _httpClient = httpClient; // Store the injected HttpClient for use in methods
        }

        // This method retrieves all devices asynchronously from the API
        public async Task<IEnumerable<Device>> GetDevicesAsync()
        {
            // Sends a GET request to the "devices" endpoint and parses the response into a collection of Device objects
            // If the response is null, returns an empty collection
            return await _httpClient.GetFromJsonAsync<IEnumerable<Device>>("devices")
                   ?? Enumerable.Empty<Device>();
        }

        // This method retrieves a specific device by its ID asynchronously
        public async Task<Device?> GetDeviceByIdAsync(string deviceId)
        {
            // Sends a GET request to the "devices/{deviceId}" endpoint and parses the response into a Device object
            return await _httpClient.GetFromJsonAsync<Device>($"devices/{deviceId}");
        }

        // This method sends data to a specific device by its ID
        public async Task<bool> SendDataToDeviceAsync(string deviceId, object data)
        {
            // Sends a POST request to the "devices/{deviceId}/data" endpoint with the provided data in JSON format
            var response = await _httpClient.PostAsJsonAsync($"devices/{deviceId}/data", data);

            // Returns true if the response status code indicates success (2xx range), otherwise returns false
            return response.IsSuccessStatusCode;
        }
    }
}
