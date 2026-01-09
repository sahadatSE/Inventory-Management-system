using System.Security.Claims;
using Business;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Admin
{
    
    public class ProductModel : PageModel
    {
        [BindProperty]
        public Product model { get; set; } = new();

        public void OnGet(int? Id = null)
        {
            if (Id != null)
            {
                Result result = new ProductService().GetProduct(Id.Value);
                model = result.Data as Product ?? new Product();
            }
        }

        public IActionResult OnPost()
        {
            model.CreatedBy = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Result result;

            if (model.P_Id == 0)
            {
                result = new ProductService().AddProduct(model);
            }
            else
            {
                result = new ProductService().UpdateProduct(model);
            }

            if (result.Success)
                return RedirectToPage("/Admin/ProductList");
            else
                return Page();
        }
    }
}
