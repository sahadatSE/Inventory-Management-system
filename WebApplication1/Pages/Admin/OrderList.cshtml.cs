using Business;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace WebApplication1.Pages.Admin
{
    public class OrderListModel : PageModel
    {
        public List<Order> Orders { get; set; } = [];

        public void OnGet()
        {
            Result result = new OrderService().GetAllOrder();
            Orders = result.Data as List<Order> ?? [];
        }

        public IActionResult OnPostDelete(int Id)
        {
            OrderService service = new();
            Result result = service.GetOrder(Id);

            if (result.Success && result.Data is Order order)
            {
                service.DeleteOrder(order);
                TempData["Msg"] = "Order deleted successfully.";
            }

            return RedirectToPage();
        }
    }
}

