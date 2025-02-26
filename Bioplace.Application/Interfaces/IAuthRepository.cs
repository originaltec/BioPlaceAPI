using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bioplace.Application.DTOs;

namespace Bioplace.Application.Interfaces
{
    // Interface for authentication-related repository operations
    public interface IAuthRepository
    {
        // Asynchronously authenticates the user with the provided username and password,
        // and returns a TokenResponse containing the authentication token
        Task<TokenResponse> AuthenticateAsync(string username, string password);
    }
}
