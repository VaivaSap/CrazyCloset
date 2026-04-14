using CrazyCloset.Models;
using CrazyCloset.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrazyCloset.Pages
{
    public class EliminationModel : PageModel
    {
        private readonly IItemEliminationService _itemEliminationService;

        public List<EliminationLog> EliminationLogs { get; set; } = new List<EliminationLog>();
        public EliminationSchedule? EliminationSchedule { get; set; }



        public EliminationModel(IItemEliminationService itemEliminationService)
        {
            _itemEliminationService = itemEliminationService;
        }

        public async Task OnGetAsync()
        {
            EliminationSchedule = await _itemEliminationService.GetScheduleAsync();
            EliminationLogs = await _itemEliminationService.GetEliminationLogsAsync();

            if (EliminationSchedule != null && DateOnly.FromDateTime(DateTime.Today) >= EliminationSchedule.ScheduledEliminationDate)
            {
                EliminationSchedule.IsActive = true;
                await _itemEliminationService.UpdateScheduleAsync(EliminationSchedule);
            }
        }

        public async Task<IActionResult> OnPostEliminateAsync(string itemForElimination)
        {
            var log = new EliminationLog
            {
                ItemName = itemForElimination,
                EliminationDate = DateOnly.FromDateTime(DateTime.Today)
            };

            await _itemEliminationService.AddEliminationLogAsync(log);

            var schedule = await _itemEliminationService.GetScheduleAsync();
            if (schedule == null)
            {
                await _itemEliminationService.AddScheduleAsync(new EliminationSchedule
                {
                    ScheduledEliminationDate = DateOnly.FromDateTime(DateTime.Today.AddDays(7)), 
                    IsActive = true
                   // WinsSpent = 0
                });
            }
            else
            {
                schedule.ScheduledEliminationDate = DateOnly.FromDateTime(DateTime.Today.AddDays(7));

                if (DateOnly.FromDateTime(DateTime.Today) >= schedule.ScheduledEliminationDate) 
                {
                    schedule.IsActive = true;
                }
                else
                {
                    schedule.IsActive = false;
                }
                
                await _itemEliminationService.UpdateScheduleAsync(schedule);
            }

            return RedirectToPage();
        }
    }
}
