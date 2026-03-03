using Business;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin
{
    public class OrderListModel(OrderService service) : PageModel
    {
        private readonly OrderService _service = service;

        public List<Order> Orders { get; set; } = [];

        public void OnGet()
        {
            Result result = _service.GetAllOrder();
            Orders = result.Data as List<Order> ?? [];
        }

        public IActionResult OnPostDelete(int Id)
        {
            Result result = _service.GetOrder(Id);
            if (result.Success && result.Data is Order order)
            {
                _service.DeleteOrder(order);
                TempData["Msg"] = "Order deleted successfully.";
            }
            return RedirectToPage();
        }
    }
}