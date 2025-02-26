using BioPlace.Domain.Entities;
using BioPlace.Domain.Entities.Devices;

namespace Bioplace.Application.Interfaces
{
    // Interface defining the methods for the Auroral service
    public interface IAuroralService
    {
        // Asynchronously retrieves a collection of devices
        Task<IEnumerable<Device>> GetDevicesAsync();

        // Asynchronously retrieves a specific device by its unique ID
        Task<Device?> GetDeviceByIdAsync(string deviceId);

        // Asynchronously sends data to a specified device
        Task<bool> SendDataToDeviceAsync(string deviceId, object data);
    }
}
