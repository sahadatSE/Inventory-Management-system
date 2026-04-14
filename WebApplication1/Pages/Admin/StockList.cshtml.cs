using Business;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin
{
    [Authorize(Roles = "1,2")]
    public class StockListModel(StockService service) : PageModel
    {
        private readonly StockService _service = service;

        public List<Stock> Stocks { get; set; } = [];
        public List<Stock> AvailableStocks { get; set; } = []; 
        public void OnGet()
        {
            
            Result result = _service.GetAllStocks();
            Stocks = result.Data as List<Stock> ?? [];

            Result availResult = _service.GetAvailableStocks();
            AvailableStocks = availResult.Data as List<Stock> ?? [];
        }

        public IActionResult OnPostDelete(int Id)
        {
            Result deleteResult = _service.DeleteStock(Id);

            if (deleteResult.Success)
                TempData["SuccessMessage"] = deleteResult.Message;
            else
                TempData["ErrorMessage"] = deleteResult.Message;

            return RedirectToPage();
        }
    }
}