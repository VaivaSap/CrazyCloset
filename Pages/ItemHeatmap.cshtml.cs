using CrazyCloset.Models;
using CrazyCloset.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrazyCloset.Pages
{
    public class ItemHeatmap : PageModel
    {
        private readonly IInventoryService _inventoryService;

        public List<UseLogDto> ItemLogs { get; set; } = new List<UseLogDto>();
        public List<ClothesItem> ClothesItems { get; set; } = new List<ClothesItem>();


        public ItemHeatmap(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public async Task OnGetAsync(long id)
        {
            ItemLogs = await _inventoryService.GetAllLogsByIdAsync(id); 
        }
    }
}
