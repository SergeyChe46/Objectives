using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Objectives.Helpers.Mapping;
using Objectives.Models;
using Objectives.Models.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Objectives.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<Performer> _userManager;
        private readonly IConfiguration _configuration;
        private Performer? _performer;

        public AuthenticationService(UserManager<Performer> userManager,
                                     IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult> RegisterUser(PerformerViewModel performerViewModel)
        {
            Performer newPerformer = PerformerMapping.PerformerMapper(performerViewModel);
            var result = await _userManager.CreateAsync(newPerformer, performerViewModel.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(newPerformer, performerViewModel.Roles);
            }
            return result;
        }

        public async Task<bool> Authenticate(PerformerAuthentication performerAuthentication)
        {
            _performer = await _userManager.FindByNameAsync(performerAuthentication.Name);
            var result = 
                _performer != null &&
                await _userManager.CheckPasswordAsync(_performer, performerAuthentication.Password);
            // Добавить логирование
            if (!result) await Console.Out.WriteLineAsync("Пароли не совпали");
            return result;
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes("SECRET SECRET SECRET SECRET SECRET");
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _performer!.UserName)
            };
            var roles = await _userManager.GetRolesAsync(_performer);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials,
                                                      List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken
            (
                issuer: jwtSettings["validIssuer"],
                audience: jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
                signingCredentials: signingCredentials
            );
            return tokenOptions;
        }
    }
}
