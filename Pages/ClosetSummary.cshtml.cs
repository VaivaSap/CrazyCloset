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

        public async Task<IActionResult> OnPostEditAsync(
            long Id,
            string Name,
            string? Description,
            string? Season,
            string? Size,
            DateOnly? ArrivedDate,
            string Category,
            IFormFile? ImageFile)
        {
            var item = new ClothesItem
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Season = Season,
                Category = Category,
                Size = Size,
                ArrivedDate = ArrivedDate
            };
            await _inventoryService.EditItemAsync(item, ImageFile);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(long id)
        {
            await _inventoryService.DeleteClothesItemAsync(id);
            return RedirectToPage();
        }
    }
}
