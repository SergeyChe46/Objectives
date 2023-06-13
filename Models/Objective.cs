using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Objectives.Models
{
    [Index(nameof(Title), IsUnique = true)]
    public class Objective
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Priority { get; set; }
        public virtual List<Performer>? Performers { get; set; }
    }
}
