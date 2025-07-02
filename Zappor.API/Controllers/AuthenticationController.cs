
using Microsoft.AspNetCore.Mvc;
using Zappor.Application.DTO;
using Zappor.Application.Services;

namespace Zappor.API.Controllers
{
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AuthenticationDTO authenticationDTO)
        {
            try
            {
                var token = await _authenticationService.RegisterAsync(authenticationDTO);
                return Ok(new { Token = token });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthenticationDTO authenticationDTO)
        {
            var token = await _authenticationService.LoginAsync(authenticationDTO);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(new { Token = token });
        }
    }
}
