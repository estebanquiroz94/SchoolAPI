using Microsoft.AspNetCore.Identity;

namespace SchoolAPI.Interfaces.Services
{
    public interface IAuthenticationService
    {
        string GenerateToken(string username, string password);
        Task<SignInResult> Authenticate(string username, string password);
    }
}
