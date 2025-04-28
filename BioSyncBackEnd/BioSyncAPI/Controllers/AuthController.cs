using BioSync.Application.DTOs;
using BioSync.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BioSync.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            try
            {
                var token = await _authenticationService.Authenticate(loginDto.Email, loginDto.Senha);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }
    }
}
