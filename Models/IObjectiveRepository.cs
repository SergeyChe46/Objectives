namespace Objectives.Models
{
    public interface IObjectiveRepository
    {
        Task CreateObjectiveAsync(Objective objective);
        Task<Objective?> GetObjectiveAsync(int id);
        Task<List<Objective>> GetObjectivesAsync(string title);
        Task<List<Objective>> GetObjectivesAsync();
        Task<List<Objective>> GetObjectivesByPriorityAsync(string priority);
        Task<List<Objective>> GetObjectivesByPerformerAsync(int id);
        Task UpdateObjectiveAsync(Objective objective);
        Task StartObjectiveAsync(int objectiveId, int performerId);
    }
}