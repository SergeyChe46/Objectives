using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Objectives.Models
{
    public class Performer : IdentityUser
    {
        [Key]
        public new Guid Id { get; set; }
        public virtual List<Objective>? Objectives { get; set; }
    }
}
