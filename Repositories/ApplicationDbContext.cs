using Microsoft.EntityFrameworkCore;
using Objectives.Models;

namespace Objectives.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options){ }

        public DbSet<Objective> Objectives{ get; set; }
        public DbSet<Performer> Performers { get; set; }
    }
}
