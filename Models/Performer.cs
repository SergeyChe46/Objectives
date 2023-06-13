using System.ComponentModel.DataAnnotations;

namespace Objectives.Models
{
    public class Performer
    {
        [Key]
        public Guid Id { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public string? Name { get; set; }
        public virtual List<Objective>? Objectives { get; set; }
    }
}
