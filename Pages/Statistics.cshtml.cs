using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrazyCloset.Pages
{
    public class PatternsModel : PageModel
    {
        private readonly ILogger<PatternsModel> _logger;

        public PatternsModel(ILogger<PatternsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }

}
