using Microsoft.EntityFrameworkCore;
using Objectives.Models.ViewModels;
using Objectives.Repositories;
using System.Collections.Generic;

namespace Objectives.Models
{
    public class ObjectiveRepository : IObjectiveRepository
    {
        private readonly ApplicationDbContext _context;

        public ObjectiveRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Возвращает все доступные задачи.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Objective>> GetObjectivesAsync()
        {
            return await _context.Objectives
                .Include(p => p.Performers)
                .Select(
                    o =>
                        new Objective
                        {
                            ObjectiveId = o.ObjectiveId,
                            Title = o.Title,
                            Description = o.Description,
                            Priority = o.Priority,
                            Performers = o.Performers.ToList()
                        }
                )
                .ToListAsync();
        }

        /// <summary>
        /// Создаёт задачу.
        /// </summary>
        /// <param name="objective">Новая задача.</param>
        /// <returns></returns>
        public async Task CreateObjectiveAsync(Objective objective)
        {
            _context.Objectives.Add(objective);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Обновляет задачу.
        /// </summary>
        /// <param name="objective">Параметры задачи для обновления.</param>
        /// <returns></returns>
        public async Task UpdateObjectiveAsync(Objective objective)
        {
            _context.Objectives.Update(objective);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Назанчает исполнителя для задачи.
        /// </summary>
        /// <param name="objectiveId">Id задачи.</param>
        /// <param name="performerId">Id исполнителя.</param>
        /// <returns></returns>
        public async Task StartObjectiveAsync(int objectiveId, int performerId)
        {
            var obj = await _context.Objectives
                .Include(p => p.Performers)
                .FirstOrDefaultAsync(o => o.ObjectiveId == objectiveId);

            var perf = await _context.Performers.FirstOrDefaultAsync(
                p => p.PerformerId == performerId
            );

            if (obj != null && perf != null)
            {
                obj.Performers!.Add(perf);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Возвращает задачу по Id.
        /// </summary>
        /// <param name="objectiveId"></param>
        /// <returns></returns>
        public async Task<Objective?> GetObjectiveAsync(int objectiveId)
        {
            return await _context.Objectives.FindAsync(objectiveId);
        }
    }
}
