namespace Objectives.Models
{
    public interface IObjectiveRepository
    {
        Task CreateObjectiveAsync(Objective objective);
        Task<Objective?> GetObjectiveAsync(Guid id);
        Task<List<Objective>> GetObjectivesAsync(string title);
        Task<List<Objective>> GetObjectivesAsync();
        Task<List<Objective>> GetObjectivesAsync(Priority priority);
        Task<List<Objective>> GetObjectivesByPerformerAsync(Guid id);
        Task UpdateObjectiveAsync(Objective objective);
    }
}