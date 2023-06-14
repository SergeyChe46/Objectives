using Microsoft.AspNetCore.Identity;
using Objectives.Models.ViewModels;

namespace Objectives.Authentication
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(PerformerViewModel performerViewModel);
        Task<bool> Authenticate(PerformerAuthentication performerAuthentication);
        Task<string> CreateToken();
    }
}
