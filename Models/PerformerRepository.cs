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

        public async Task<List<Performer>> GetAllPerformers()
        {
            return await _context.Performers.ToListAsync();
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
