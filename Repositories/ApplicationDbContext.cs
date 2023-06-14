using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Objectives.Models;
using Objectives.Services;

namespace Objectives.Repositories
{
    public class ApplicationDbContext : IdentityDbContext<Performer>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }

        public DbSet<Objective> Objectives{ get; set; }
        public DbSet<Performer> Performers { get; set; }
    }
}
