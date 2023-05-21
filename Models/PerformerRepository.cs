using Microsoft.EntityFrameworkCore;
using Objectives.Repositories;

namespace Objectives.Models
{
    public class PerformerRepository : IPerformerRepository
    {
        private readonly ApplicationDbContext _context;

        public PerformerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreatePerformerAsync(Performer performer)
        {
            await _context.Performers.AddAsync(performer);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Performer>> GetAllPerformers()
        {
            return await _context.Performers
                .Include(p => p.Objectives)
                .Select(
                    obj =>
                        new Performer
                        {
                            PerformerId = obj.PerformerId,
                            Email = obj.Email,
                            Name = obj.Name,
                            Objectives = obj.Objectives!.ToList()
                        }
                )
                .ToListAsync();
        }

        public async Task<List<Performer>> GetFreePerformers()
        {
            return await _context.Performers
                .AsQueryable()
                .Where(perf => perf.Objectives!.Count == 0)
                .ToListAsync();
        }
    }
}
