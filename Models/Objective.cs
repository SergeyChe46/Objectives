using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Objectives.Models
{
    [Index(nameof(Title), IsUnique = true)]
    [PrimaryKey(nameof(ObjectiveId))]
    public class Objective
    {
        public int ObjectiveId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
        public string Priority { get; set; }
        public virtual List<Performer>? Performers { get; set; }
    }
}
