using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Objectives.Authentication;
using Objectives.Models.ViewModels;

namespace Objectives.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] PerformerViewModel performerViewModel)
        {
            var result = await _authenticationService.RegisterUser(performerViewModel);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] PerformerAuthentication user)
        {
            if (!await _authenticationService.Authenticate(user))
                return Unauthorized();

            return Ok(new
            {
                Token = await _authenticationService.CreateToken()
            });
        }
    }
}
