using System.ComponentModel.DataAnnotations;

namespace Objectives.Models
{
    public class Objective
    {
        [Key]
        public Guid ObjectiveId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public Guid? PerformerId { get; set; }
        public ICollection<Performer>? Performers { get; set; }
    }

    public enum Priority
    {
        Low, Medium, High
    }
}
