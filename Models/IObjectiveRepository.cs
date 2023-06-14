namespace Objectives.Models
{
    public interface IObjectiveRepository
    {
        Task CreateObjectiveAsync(Objective objective);
        Task<Objective?> GetObjectiveAsync(Guid id);
        Task<IEnumerable<Objective>> GetObjectivesAsync();
        Task UpdateObjectiveAsync(Objective objective);
        Task StartObjectiveAsync(Guid objectiveId, Guid performerId);
    }
}