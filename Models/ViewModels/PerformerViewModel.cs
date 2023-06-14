using System.ComponentModel.DataAnnotations;

namespace Objectives.Models.ViewModels
{
    public class PerformerViewModel
    {
        [Required]
        public string Email { get; set; }
        public string? Name { get; set; }
        public string Password { get; set; }
        public ICollection<string> Roles { get; set; }
    }
}
