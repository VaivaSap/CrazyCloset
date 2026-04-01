using CrazyCloset.Models;

namespace CrazyCloset.Services
{
    public interface IItemEliminationService
    {
        Task<List<EliminationLog>> GetEliminationLogsAsync();
        Task<EliminationLog> AddEliminationLogAsync(EliminationLog log);
        Task<EliminationSchedule> GetScheduleAsync();
        Task UpdateScheduleAsync(EliminationSchedule schedule);
        Task<int> GetTotalEliminationsAsync();
    }
}
