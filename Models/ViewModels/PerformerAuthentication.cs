using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Objectives.Models.ViewModels
{
    public class PerformerAuthentication
    {
        [Required(ErrorMessage = "Обязательно")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Обязательно")]
        public string Password { get; set; }
    }
}
