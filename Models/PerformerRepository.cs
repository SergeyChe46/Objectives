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

        /// <summary>
        /// Создат нового исполнителя.
        /// </summary>
        /// <param name="performer">Параметры исполнителя.</param>
        /// <returns></returns>
        public async Task CreatePerformerAsync(Performer performer)
        {
            await _context.Performers.AddAsync(performer);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Возвращает всех исполнителей.
        /// </summary>
        /// <returns></returns>
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
                            UserName = obj.UserName,
                            Objectives = obj.Objectives!.ToList()
                        }
                )
                .ToListAsync();
        }

        /// <summary>
        /// Возвращает исполнителя с заданной почтой.
        /// </summary>
        /// <param name="email">Почта исполнителя.</param>
        /// <returns></returns>
        public async Task<Performer?> GetPerformer(string email)
        {
            return await _context.Performers
                .AsQueryable()
                .Include(p => p.Objectives)
                .Select(
                    p =>
                        new Performer
                        {
                            PerformerId = p.PerformerId,
                            Email = p.Email,
                            UserName = p.UserName,
                            Objectives = p.Objectives!.ToList()
                        }
                )
                .FirstOrDefaultAsync(perf => perf.Email == email);
        }

        /// <summary>
        /// Возвращает свободных исполниетелей.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Performer>> GetFreePerformers()
        {
            return await _context.Performers
                .AsQueryable()
                .Where(perf => perf.Objectives!.Count == 0)
                .ToListAsync();
        }
    }
}
