using System.ComponentModel.DataAnnotations;

namespace Objectives.Models
{
    public class Performer
    {
        [Key]
        public Guid PerformerId { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public string? Name { get; set; }
        public Guid? ObjectiveId { get; set; }
        public ICollection<Objective>? Objectives { get; set; }
    }
}
