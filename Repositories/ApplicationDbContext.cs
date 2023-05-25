using Microsoft.EntityFrameworkCore;
using Objectives.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Objectives.Repositories.Configuration;

namespace Objectives.Repositories
{
    public class ApplicationDbContext : IdentityDbContext<Performer> //DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ObjectiveConfiguration());
            builder.ApplyConfiguration(new PerformerConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
        }

        public DbSet<Objective> Objectives { get; set; }
        public DbSet<Performer> Performers { get; set; }
    }
}
