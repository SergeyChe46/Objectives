﻿using System.ComponentModel.DataAnnotations;

namespace Objectives.Models
{
    public class Performer
    {
        [Key]
        public int PerformerId { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public string? Name { get; set; }
        public int? ObjectiveId { get; set; }
        public ICollection<Objective>? Objectives { get; set; }
    }
}