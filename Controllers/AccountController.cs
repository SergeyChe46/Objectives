using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Objectives.Models;
using Objectives.Models.ViewModels;

namespace Objectives.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<Performer> _userManager;

        public AccountController(UserManager<Performer> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(
            [FromBody] PerformerViewModel userForRegistration
        )
        {
            Performer performer =
                new()
                {
                    Email = userForRegistration.Email,
                    UserName = userForRegistration.UserName
                };
            var result = await _userManager.CreateAsync(performer, userForRegistration.Password);
            System.Console.WriteLine(performer);
            if (!result.Succeeded)
            {
                System.Console.WriteLine("DONE");
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            await _userManager.AddToRolesAsync(performer, userForRegistration.Roles);
            System.Console.WriteLine("DSADSDSADASDAS");
            return StatusCode(201);
        }
    }
}
