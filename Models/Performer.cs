using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Objectives.Models
{
    [PrimaryKey(nameof(PerformerId), nameof(Email))]
    public class Performer : IdentityUser
    {
        public int PerformerId { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public string? Name { get; set; }
        public virtual List<Objective>? Objectives { get; set; }
    }
}
