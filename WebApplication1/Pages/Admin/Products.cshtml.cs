using Business;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin
{
    [Authorize(Roles = "1,2")]
    public class ProductListModel(ProductService productService, StockService stockService) : PageModel
    {
        private readonly ProductService _productService = productService;
        private readonly StockService _stockService = stockService;

        public List<Product> Products { get; set; } = [];
        public Dictionary<int, int> StockSummary { get; set; } = [];

        public void OnGet()
        {
            Result result = _productService.GetAllProduct();
            Products = result.Data as List<Product> ?? [];

            Result stockResult = _stockService.GetAvailableStocks();
            var stocks = stockResult.Data as List<Stock> ?? [];

            StockSummary = stocks
           .GroupBy(s => s.P_Id)
           .ToDictionary(
            g => g.Key,
            g => g.Sum(s => s.Quantity_In) - g.Sum(s => s.Quantity_Out)
    );
        }

        public IActionResult OnPostDelete(int Id)
        {
            Result getResult = _productService.GetProduct(Id);
            if (!getResult.Success)
            {
                TempData["ErrorMessage"] = getResult.Message;
                return RedirectToPage();
            }

            Product product = getResult.Data as Product ?? new Product();
            Result deleteResult = _productService.DeleteProduct(product);

            if (deleteResult.Success)
                TempData["SuccessMessage"] = deleteResult.Message;
            else
                TempData["ErrorMessage"] = deleteResult.Message;

            return RedirectToPage();
        }
    }
}