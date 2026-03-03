using System.Security.Claims;
using Business;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin
{
    public class ProductModel(ProductService service) : PageModel
    {
        private readonly ProductService _service = service;

        [BindProperty]
        public Product Model { get; set; } = new();

        public void OnGet(int? Id = null)
        {
            if (Id != null)
            {
                Result result = _service.GetProduct(Id.Value);
                Model = result.Data as Product ?? new Product();
            }
        }

        public IActionResult OnPost()
        {
            Model.CreatedBy = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Result result;
            if (Model.P_Id == 0)
                result = _service.AddProduct(Model);
            else
                result = _service.UpdateProduct(Model);

            if (result.Success)
                return RedirectToPage("/Admin/ProductList");
            else
                return Page();
        }
    }
}