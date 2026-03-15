using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin
{
    public class SupplierListModel(SupplierService service) : PageModel
    {
        private readonly SupplierService _service = service;

        public List<Supplier> List { get; set; } = new();
        public string SearchQuery { get; set; } = string.Empty;

        public void OnGet(string? search)
        {
            var result = _service.GetAllSupplier();
            var all = result.Success ? result.Data as List<Supplier> ?? new() : new();

            if (!string.IsNullOrWhiteSpace(search))
            {
                SearchQuery = search;
                List = all.Where(s => s.SName.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                List = all;
            }
        }

        public IActionResult OnPostDelete(int id)
        {
            var result = _service.DeleteSupplier(id);
            if (result.Success)
                TempData["SuccessMessage"] = result.Message;
            return RedirectToPage();
        }
    }
}