using CrazyCloset.Models;
using CrazyCloset.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrazyCloset.Pages
{
    public class ClosetSummaryModel : PageModel
    {
        private readonly IInventoryService _inventoryService;

        public List<CategoryDto> CategoryCounts { get; set; } = new List<CategoryDto>();

        public List<ClothesItem> Items { get; set; } = new List<ClothesItem>();

        public List<ClothesItem> ClothingPictures { get; set; } = new List<ClothesItem>();

        public ClosetSummaryModel(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public async Task OnGetAsync()
        {
            CategoryCounts = await _inventoryService.GetItemsByCategoryAsync();
            Items = await _inventoryService.GetAllClothesAsync();
        }

        public async Task<IActionResult> OnPostCheckInAsync(long id)
        {
            var log = new UseLog
            {
                ItemId = id,
                UsedDate = DateOnly.FromDateTime(DateTime.Today)
            };
            await _inventoryService.ItemCheckIn(log);
            return RedirectToPage();
        }
    }
}
