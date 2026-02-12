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

        public List<ClothesItem> Items { get; set; } = new List<ClothesItem>();

       public List<ClothesItem> ClothingPictures { get; set; } = new List<ClothesItem>();

        public IndexModel(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public async Task OnGetAsync()
        {
            Items = await _inventoryService.GetAllClothesAsync();
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

        public async Task<IActionResult> OnPostDeleteAsync(long id)
        {
            await _inventoryService.DeleteClothesItemAsync(id);

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
    }
}
