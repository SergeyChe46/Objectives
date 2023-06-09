﻿using Microsoft.EntityFrameworkCore;
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
                            Id = obj.Id,
                            Email = obj.Email,
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
                .Where(p => p.Email == email)
                .Include(p => p.Objectives)
                .Select(
                    p =>
                        new Performer
                        {
                            Id = p.Id,
                            Email = p.Email,
                            Objectives = p.Objectives!.ToList()
                        }
                )
                .FirstOrDefaultAsync();
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
