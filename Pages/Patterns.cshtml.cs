using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CrazyCloset.Models;
using CrazyCloset.Services;

namespace CrazyCloset.Pages
{
    [AllowAnonymous]
    public class PatternsModel : PageModel
    {
        private readonly IInventoryService _inventoryService;

        public List<UseLogDto> Logs { get; set; } = new List<UseLogDto>();
        public List<UseLogDto> ItemLogs { get; set; } = new List<UseLogDto>();

        public PatternsModel(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public async Task OnGetAsync()
        {
            Logs = await _inventoryService.GetUseLogsAsync();
        }
    }

}
