using BioPlace.Domain.Entities;
using BioPlace.Domain.Entities.Devices;

namespace Bioplace.Application.Interfaces
{
    public interface IAuroralService
    {
        Task<IEnumerable<Device>> GetDevicesAsync();
        Task<Device?> GetDeviceByIdAsync(string deviceId);
        Task<bool> SendDataToDeviceAsync(string deviceId, object data);
    }
}
