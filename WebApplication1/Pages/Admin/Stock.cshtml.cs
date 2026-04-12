using Business;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin
{
    [Authorize(Roles = "1")]
    public class StockModel(StockService stockService, ProductService productService) : PageModel
    {
        private readonly StockService _stockService = stockService;
        private readonly ProductService _productService = productService;

        [BindProperty]
        public Stock StockData { get; set; } = new();

        [BindProperty]
        public bool IsEdit { get; set; } = false;

        public List<Product> Products { get; set; } = [];

        public void OnGet(int? Id = null)
        {
            Result productResult = _productService.GetAllProduct();
            Products = productResult.Data as List<Product> ?? [];

            if (Id != null)
            {
                Result result = _stockService.GetStock(Id.Value);
                StockData = result.Data as Stock ?? new Stock();
                IsEdit = true;
            }
        }

        public IActionResult OnPost()
        {
            ModelState.Clear();

            Result productResult = _productService.GetAllProduct();
            Products = productResult.Data as List<Product> ?? [];

            Result result;

            if (!IsEdit)
                result = _stockService.AddStock(StockData);
            else
                result = _stockService.UpdateStock(StockData);

            if (result.Success)
            {
                TempData["SuccessMessage"] = result.Message;
                return RedirectToPage("/Admin/StockList");
            }
            else
            {
                ModelState.AddModelError("", result.Message);
                return Page();
            }
        }
    }
}