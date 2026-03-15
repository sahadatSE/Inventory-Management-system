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
            Result result = _service.GetAllOrders();
            Orders = result.Data as List<Order> ?? [];
        }

        public IActionResult OnPostDelete(int Id)
        {
            Result result = _service.DeleteOrder(Id);
            if (result.Success)
                TempData["SuccessMessage"] = result.Message;
            else
                TempData["ErrorMessage"] = result.Message;
            return RedirectToPage();
        }

        public IActionResult OnPostUpdateStatus(int OrderId, string Status)
        {
            Result result = _service.UpdateStatus(OrderId, Status);
            if (result.Success)
                TempData["SuccessMessage"] = result.Message;
            else
                TempData["ErrorMessage"] = result.Message;
            return RedirectToPage();
        }
    }
}