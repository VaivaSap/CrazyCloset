using CrazyCloset.Models;

namespace CrazyCloset.Repositories
{
    public interface IItemEliminationRepository
    {
        Task<List<EliminationLog>> GetEliminationLogsAsync();
        Task<EliminationLog> AddEliminationLogAsync(EliminationLog log);
        Task<EliminationSchedule?> GetScheduleAsync();
        Task AddScheduleAsync(EliminationSchedule schedule);
        Task UpdateScheduleAsync(EliminationSchedule schedule);
        Task<int> GetTotalEliminationsAsync();
    }
}
