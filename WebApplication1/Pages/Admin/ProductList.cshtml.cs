using Business;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin
{
    [Authorize(Roles = "1,2")]
    public class ProductModel(ProductService productService) : PageModel
    {
        private readonly ProductService _productService = productService;

        [BindProperty]
        public Product ProductData { get; set; } = new();

        [BindProperty]
        public bool IsEdit { get; set; } = false;

        public void OnGet(int? Id = null)
        {
            if (Id != null)
            {
                Result result = _productService.GetProduct(Id.Value);
                ProductData = result.Data as Product ?? new Product();
                IsEdit = true;
            }
        }

        public IActionResult OnPost()
        {
            ModelState.Clear();
            Result result;

            if (!IsEdit)
                result = _productService.AddProduct(ProductData);
            else
                result = _productService.UpdateProduct(ProductData);

            if (result.Success)
            {
                TempData["SuccessMessage"] = result.Message;
                return RedirectToPage("/Admin/ProductList");
            }
            else
            {
                ModelState.AddModelError("", result.Message);
                return Page();
            }
        }
    }
}