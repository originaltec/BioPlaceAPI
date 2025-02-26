using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioplace.Application.DTOs
{
    // Data Transfer Object (DTO) representing a login request
    public class LoginRequestDto
    {
        // Property to hold the username for login
        public string Username { get; set; }

        // Property to hold the password for login
        public string Password { get; set; }
    }
}
