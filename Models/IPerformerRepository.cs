namespace Objectives.Models
{
    public interface IPerformerRepository
    {
        Task CreatePerformerAsync(Performer performer);
        Task<List<Performer>> GetAllPerformers();
        Task<List<Performer>> GetFreePerformers();
        Task<Performer?> GetPerformer(string email);
    }
}
