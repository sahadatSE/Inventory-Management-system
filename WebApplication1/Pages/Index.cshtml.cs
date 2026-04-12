using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private List<string> roles;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            roles = new List<string>()
            { "1","2" };
        }
    }
}
