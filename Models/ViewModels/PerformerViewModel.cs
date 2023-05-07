using System.ComponentModel.DataAnnotations;

namespace Objectives.Models.ViewModels
{
    public class PerformerViewModel
    {
        [Required]
        public string Email { get; set; }
        public string? Name { get; set; }
    }
}
