using Business;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace WebApplication1.Pages.Admin
{
    public class ProductListModel : PageModel
    {
        public List<Product> Products { get; set; } = [];

        public void OnGet()
        {
            Result result = new ProductService().GetAllProduct();
            Products = result.Data as List<Product> ?? [];
        }

        public IActionResult OnPostDelete(int Id)
        {
            ProductService service = new();
            Result result = service.GetProduct(Id);

            if (result.Success && result.Data is Product product)
            {
                service.DeleteProduct(product);
                TempData["Msg"] = "Order details deleted successfully.";
            }


            return RedirectToPage();
        }
    }
}
