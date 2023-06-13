namespace Objectives.Models
{
    public interface IObjectiveRepository
    {
        Task CreateObjectiveAsync(Objective objective);
        Task<Objective?> GetObjectiveAsync(Guid id);
        Task<List<Objective>> GetObjectivesAsync(int page, int numOfEntities);
        Task UpdateObjectiveAsync(Objective objective);
        Task StartObjectiveAsync(Guid objectiveId, Guid performerId);
    }
}