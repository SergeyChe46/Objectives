using System.ComponentModel.DataAnnotations;

namespace Objectives.Models
{
    public class Objective
    {
        [Key]
        public int ObjectiveId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public ICollection<int>? PerformersId { get; set; }
    }

    public enum Priority
    {
        Low, Medium, High
    }
}
