using CrazyCloset.Models;
using CrazyCloset.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrazyCloset.Pages
{
    public class ClosetSummaryModel : PageModel
    {
        private readonly IInventoryService _inventoryService;

        public List<CategoryDto> CategoryCounts { get; set; } = new List<CategoryDto>();

        public ClosetSummaryModel(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public async Task OnGetAsync()
        {
            CategoryCounts = await _inventoryService.GetItemsByCategoryAsync();
        }
    }
}
