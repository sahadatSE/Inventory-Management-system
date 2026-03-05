using Business;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin
{
    public class NotificationModel(StockService stockService) : PageModel
    {
        private readonly StockService _stockService = stockService;

        public List<Stock> LowStockList { get; set; } = new();
        public List<Stock> OutOfStockList { get; set; } = new();

        public void OnGet()
        {
            Result result = _stockService.GetAvailableStocks();
            if (result.Success)
            {
                var all = result.Data as List<Stock> ?? new();

               
                OutOfStockList = all
                    .Where(s => s.Available_Stock <= 0)
                    .ToList();

         
                LowStockList = all
                    .Where(s => s.Available_Stock > 0 && s.Available_Stock <= 2)
                    .ToList();
            }
        }
    }
}