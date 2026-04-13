using Business;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin
{
    public class DashboardModel(UserService userService, StockService stockService) : PageModel
    {
        private readonly UserService _userService = userService;
        private readonly StockService _stockService = stockService;

        public int TotalUsers { get; set; }
        public int TotalStockRecords { get; set; }
        public int TotalAvailableStock { get; set; }
        public List<Stock> AvailableList { get; set; } = new();
        public List<Stock> RecentStocks { get; set; } = new();
        public object ViewBag { get; private set; }

        public void OnGet()
        {
       
            Result userResult = _userService.GetAllUser();
            if (userResult.Success)
            {
                var users = userResult.Data as List<User> ?? new();
                TotalUsers = users.Count;
            }

          
            Result stockResult = _stockService.GetAllStocks();
            if (stockResult.Success)
            {
                var stocks = stockResult.Data as List<Stock> ?? new();
                TotalStockRecords = stocks.Count;
                RecentStocks = stocks
                    .OrderByDescending(s => s.EntryDate)
                    .Take(5)
                    .ToList();
            }

      
            Result availableResult = _stockService.GetAvailableStocks();
            if (availableResult.Success)
            {
                AvailableList = availableResult.Data as List<Stock> ?? new();
                TotalAvailableStock = AvailableList.Sum(s => s.Available_Stock);
            }


        }

    }
   
}
