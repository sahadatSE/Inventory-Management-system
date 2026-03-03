using Business;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin
{
    public class ProductListModel(ProductService service) : PageModel
    {
        private readonly ProductService _service = service;

        public List<Product> Products { get; set; } = [];

        public void OnGet()
        {
            Result result = _service.GetAllProduct();
            Products = result.Data as List<Product> ?? [];
        }

        public IActionResult OnPostDelete(int Id)
        {
            Result result = _service.GetProduct(Id);
            if (result.Success && result.Data is Product product)
            {
                _service.DeleteProduct(product);
                TempData["Msg"] = "Product details deleted successfully.";
            }
            return RedirectToPage();
        }
    }
}