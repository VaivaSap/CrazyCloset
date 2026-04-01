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
        public EliminationSchedule EliminationSchedule { get; set; }



        public EliminationModel(IItemEliminationService itemEliminationService)
        {
            _itemEliminationService = itemEliminationService;
        }

        public async Task OnGetAsync()
        {
            EliminationSchedule = await _itemEliminationService.GetScheduleAsync();
            EliminationLogs = await _itemEliminationService.GetEliminationLogsAsync();
        }

        public async Task<IActionResult> OnPostEliminateAsync(string itemForElimination)
        {
            var log = new EliminationLog
            {
                ItemName = itemForElimination,
                EliminationDate = DateOnly.FromDateTime(DateTime.Today)
            };
            await _itemEliminationService.AddEliminationLogAsync(log);
            return RedirectToPage();
        }

    }
}

//public async Task<IActionResult> OnPostCheckInAsync(long id)
//{
//    var log = new UseLog
//    {
//        ItemId = id,
//        UsedDate = DateOnly.FromDateTime(DateTime.Today)
//    };
//    await _inventoryService.ItemCheckIn(log);
//    return RedirectToPage();
//}
