using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioPlace.Domain.Entities.Devices
{
    // Represents a device in the system
    public class Device
    {
        // Unique identifier for the device
        public string DeviceId { get; set; } = string.Empty;

        // Name of the device (could be a user-friendly name)
        public string Name { get; set; } = string.Empty;

        // Current status of the device (e.g., online, offline, active, inactive)
        public string Status { get; set; } = string.Empty;
    }
}
