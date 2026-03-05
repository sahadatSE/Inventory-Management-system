using Business;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin
{
    public class StockListModel(StockService service) : PageModel
    {
        private readonly StockService _service = service;

        public List<Stock> List { get; set; } = new();
        public List<Stock> AvailableList { get; set; } = new();

        public void OnGet()
        {
            Result result = _service.GetAllStocks();
            if (result.Success)
                List = result.Data as List<Stock> ?? new();

            Result availableResult = _service.GetAvailableStocks();
            if (availableResult.Success)
                AvailableList = availableResult.Data as List<Stock> ?? new();
        }
    }
}