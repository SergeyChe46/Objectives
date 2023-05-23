using Microsoft.EntityFrameworkCore;
using Objectives.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Objectives.Repositories
{
    public class ApplicationDbContext : IdentityDbContext<Performer> //DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Objective> Objectives { get; set; }
        public DbSet<Performer> Performers { get; set; }
    }
}
