using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Interfaces.Services;

namespace SchoolAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IAuthenticationService _authService;
        public IEncryptDecryptService _encryptDecryptService { get; }
        public IAuthenticationService AuthenticationService { get; }

        public LoginController(IAuthenticationService authenticationService, IEncryptDecryptService encryptDecryptService)
        {
            _authService = authenticationService;
            _encryptDecryptService = encryptDecryptService;
        }
        [AllowAnonymous]
        [HttpGet("GetToken")]
        public async Task<IActionResult> Authenticate(string userName, string password)
        {
            try
            {
                var siginResult = await _authService.Authenticate(userName, password);

                if (siginResult.Succeeded)
                {
                    var token = _authService.GenerateToken(userName, password);

                    if (token == null)
                    {
                        return BadRequest();
                    }

                    return Ok(token);
                }
                else
                    return BadRequest(siginResult);

            }
            catch (System.Exception ex)
            {
                return BadRequest();
            }
        }
        [AllowAnonymous]
        [HttpPost("GetPass")]
        public async Task<IActionResult> GetEncryptPassWord(string password)
        {

            var encryptedPass = _encryptDecryptService.Encrypt(password);

            return Ok(encryptedPass);
        }
    }
}
