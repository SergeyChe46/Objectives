using Microsoft.EntityFrameworkCore;
using Objectives.Repositories;

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
            return await _context.Objectives.ToListAsync();
        }

        /// <summary>
        /// Возвращает задачу по её Id.
        /// </summary>
        /// <param name="id">Id задачи.</param>
        /// <returns></returns>
        public async Task<Objective?> GetObjectiveAsync(Guid id)
        {
            var objective = await _context.Objectives.FirstOrDefaultAsync(obj => obj.ObjectiveId == id);
            return objective;
        }

        /// <summary>
        /// Возвращает все заадчи по заголовку.
        /// </summary>
        /// <param name="title">Заголовок задачи.</param>
        /// <returns></returns>
        public async Task<List<Objective>> GetObjectivesAsync(string title)
        {
            var objective = await _context.Objectives
                .AsQueryable()
                .Where(obj =>
                obj.Title.ToLower().Trim() == title.ToLower().Trim())
                .ToListAsync();
            return objective;
        }

        /// <summary>
        /// Возвращает задачи с приориретом priority.
        /// </summary>
        /// <param name="priority">Приоритет.</param>
        /// <returns></returns>
        public async Task<List<Objective>> GetObjectivesAsync(Priority priority)
        {
            var objectives = await _context.Objectives
                .AsQueryable()
                .Where(obj => obj.Priority == priority)
                .ToListAsync();
            return objectives;
        }

        /// <summary>
        /// Возвращает задачи определённого исполнителя.
        /// </summary>
        /// <param name="id">Id исполнителя.</param>
        /// <returns></returns>
        public async Task<List<Objective>> GetObjectivesByPerformerAsync(Guid id)
        {
            var objectives = await _context.Objectives
                .AsQueryable()
                .Where(obj => obj.PerformerId == id)
                .ToListAsync();
            return objectives;
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
    }
}
