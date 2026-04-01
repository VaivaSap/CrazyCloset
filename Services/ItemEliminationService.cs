using CrazyCloset.Models;
using CrazyCloset.Repositories;

namespace CrazyCloset.Services
{
    public class ItemEliminationService : IItemEliminationService
    {
        private readonly IItemEliminationRepository _itemEliminationRepository;

        public ItemEliminationService(IItemEliminationRepository itemEliminationRepository)
        {
            _itemEliminationRepository = itemEliminationRepository;
        }

        public async Task<List<EliminationLog>> GetEliminationLogsAsync()
        {
            return await _itemEliminationRepository.GetEliminationLogsAsync();
        }
        public async Task<EliminationLog> AddEliminationLogAsync(EliminationLog log)
        {
            return await _itemEliminationRepository.AddEliminationLogAsync(log);
        }

        public async Task<EliminationSchedule> GetScheduleAsync()
        {
            return await _itemEliminationRepository.GetScheduleAsync();
        }
        public async Task UpdateScheduleAsync(EliminationSchedule schedule) 
        { 
            await _itemEliminationRepository.UpdateScheduleAsync(schedule);
        }

        public async Task<int> GetTotalEliminationsAsync()
        {
            return await _itemEliminationRepository.GetTotalEliminationsAsync();
        }
    }
}
