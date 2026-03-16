using Business;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin
{
    public class OrderDetailsListModel(OrderDetailsService service) : PageModel
    {
        private readonly OrderDetailsService _service = service;

        public List<OrderDetails> Details { get; set; } = [];

        public void OnGet()
        {
            Result result = _service.GetAllOrderDetails();
            Details = result.Data as List<OrderDetails> ?? [];
        }

        public IActionResult OnPostDelete(int Id)
        {
            Result result = _service.DeleteOrderDetails(Id);

            if (result.Success)
                TempData["SuccessMessage"] = result.Message;
            else
                TempData["ErrorMessage"] = result.Message;

            return RedirectToPage();
        }
    }
}