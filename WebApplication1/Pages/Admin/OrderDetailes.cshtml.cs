using Business;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin
{
    public class OrderDetailsPageModel(
        OrderService orderService,
        OrderDetailsService orderDetailsService) : PageModel
    {
        private readonly OrderService _orderService = orderService;
        private readonly OrderDetailsService _orderDetailsService = orderDetailsService;

        public Order? OrderData { get; set; }
        public List<OrderDetails> Details { get; set; } = [];

        public void OnGet(int OrderId)
        {
            Result orderResult = _orderService.GetOrder(OrderId);
            OrderData = orderResult.Data as Order;

            Result detailsResult = _orderDetailsService.GetByOrderId(OrderId);
            Details = detailsResult.Data as List<OrderDetails> ?? [];
        }

        public IActionResult OnPostDelete(int Id, int OrderId)
        {
            Result result = _orderDetailsService.DeleteOrderDetails(Id);

            if (result.Success)
                TempData["SuccessMessage"] = result.Message;
            else
                TempData["ErrorMessage"] = result.Message;

            return RedirectToPage(new { OrderId });
        }
    }
}