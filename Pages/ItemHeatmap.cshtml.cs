using CrazyCloset.Models;
using CrazyCloset.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrazyCloset.Pages
{
    public class ItemHeatmap : PageModel
    {
        private readonly IInventoryService _inventoryService;

        public List<UseLogDto> ItemLogs { get; set; } = new List<UseLogDto>();
        public List<ItemPopularityDto> MostPopular { get; set; }
        public List<ItemPopularityDto> LeastPopular { get; set; }


        public ItemHeatmap(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public async Task OnGetAsync(long id)
        {
            ItemLogs = await _inventoryService.GetAllLogsByIdAsync(id);

            var all = await _inventoryService.GetItemPopularity();
            MostPopular = all.Take(5).ToList();
            LeastPopular = all.TakeLast(5).ToList();
        }
    }
}
