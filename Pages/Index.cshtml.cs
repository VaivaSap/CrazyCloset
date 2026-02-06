using CrazyCloset.Data;
using CrazyCloset.Models;
using CrazyCloset.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrazyCloset.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IInventoryService _inventoryService;

        public List<ClothesItem> Items { get; set; }

        public List<ClothesItem> ClothingPictures { get; set; } = new List<ClothesItem>();

        public IndexModel(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public async Task OnGetAsync()
        {
            ClothingPictures = await _inventoryService.GetAllClothesAsync();
        }

        public async Task<IActionResult> OnPostAsync(
         string Name,
         string Category,
         string? Description,
         string? Season,
         string? Size,
         DateOnly? LastWornDate,
         IFormFile ImageFile)
        {
            if (ImageFile == null)
            {
                ModelState.AddModelError("", "Please select an image");
                return Page();
            }

            var item = new ClothesItem
            {
                Name = Name,
                Description = Description,
                Season = Season,
                Category = Category,
                Size = Size,
                LastWornDate = LastWornDate
            };

            await _inventoryService.SaveClothesItem(item, ImageFile);

            return RedirectToPage();
        }
    }
}
