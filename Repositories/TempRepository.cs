using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Objectives.Models;

namespace Objectives.Repositories
{
    public class TempRepository : IObjectiveRepository
    {
        private readonly List<Objective> objs = new()
        {
            new Objective{ ObjectiveId = 1, Title = "First", Description = "First description", Priority = "Low" },
            new Objective{ ObjectiveId = 2, Title = "Second", Description = "Second description", Priority = "Low" },
            new Objective{ ObjectiveId = 3, Title = "Third", Description = "Third description", Priority = "Low" },
            new Objective{ ObjectiveId = 4, Title = "Fourth", Description = "Fourth description", Priority = "Low" },
            new Objective{ ObjectiveId = 5, Title = "Fifth", Description = "Fifth description", Priority = "Low" },
            new Objective{ ObjectiveId = 6, Title = "Sixth", Description = "Sixth description", Priority = "Low" }
    };

        public Task CreateObjectiveAsync(Objective objective)
        {
            return Task.Run(() => objs.Add(objective));
        }

        public async Task<Objective?> GetObjectiveAsync(int id)
        {
            return await Task.Run(() => objs.FirstOrDefault(o => o.ObjectiveId == id));
        }

        public async Task<List<Objective>> GetObjectivesAsync()
        {
            return await Task.Run(() => objs);
        }

        public async Task StartObjectiveAsync(int objectiveId, int performerId)
        {
            Objective obj = objs.FirstOrDefault(o => o.ObjectiveId == objectiveId)!;
            await Task.Run(() => obj?.PerformersId!.Add(performerId));
        }

        public async Task UpdateObjectiveAsync(Objective objective)
        {
            var currentObj = await Task.Run(() => objs.FindIndex(o => o.ObjectiveId == objective.ObjectiveId));
            if (currentObj != -1)
            {
                objs[currentObj] = objective;
            }
        }
    }
}