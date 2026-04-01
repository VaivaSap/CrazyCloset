using CrazyCloset.Data;
using CrazyCloset.Models;
using Microsoft.EntityFrameworkCore;

namespace CrazyCloset.Repositories
{
    public class ItemEliminationRepository : IItemEliminationRepository
    {

        private readonly ApplicationDbContext _context;

        public ItemEliminationRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<List<EliminationLog>> GetEliminationLogsAsync()
        {
            return await _context.EliminationLogs.ToListAsync();
        }

        public async Task<EliminationLog> AddEliminationLogAsync(EliminationLog log)
        {
            _context.EliminationLogs.Add(log);
            await _context.SaveChangesAsync();
            return log;
        }

        public async Task<EliminationSchedule> GetScheduleAsync()
        {
            return await _context.EliminationSchedules.FirstOrDefaultAsync();
        }

        public async Task UpdateScheduleAsync(EliminationSchedule schedule)
        {
            _context.EliminationSchedules.Update(schedule);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetTotalEliminationsAsync()
        {
            return await _context.EliminationLogs.CountAsync();
        }
    }
}
