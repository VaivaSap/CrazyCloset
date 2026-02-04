using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrazyCloset.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<string> ClothingPictures { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var picsPath = Path.Combine(path, "crazycloset_items", "Items");

            ClothingPictures = Directory.GetFiles(picsPath).Select(f => Path.GetFileName(f)).ToList();
        }
    }
}
