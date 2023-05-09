namespace Objectives.Models
{
    public interface IObjectiveRepository
    {
        Task CreateObjectiveAsync(Objective objective);
        Task<Objective?> GetObjectiveAsync(int id);
        Task<List<Objective>> GetObjectivesAsync();
        Task UpdateObjectiveAsync(Objective objective);
        Task StartObjectiveAsync(int objectiveId, int performerId);
    }
}