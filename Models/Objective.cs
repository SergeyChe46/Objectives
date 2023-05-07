using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Objectives.Models
{
    [Index(nameof(Title), IsUnique = true)]
    public class Objective
    {
        [Key]
        public int ObjectiveId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Priority { get; set; }
        public List<int>? PerformersId { get; set; }
    }
}
