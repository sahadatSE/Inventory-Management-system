using Business;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin
{
    public class OrderDetailesListModel(OrderDetailesService service) : PageModel
    {
        private readonly OrderDetailesService _service = service;

        public List<OrderDetails> OrderDetails { get; set; } = [];

        public void OnGet()
        {
            Result result = _service.GetAllOrderDetails();
            OrderDetails = result.Data as List<OrderDetails> ?? [];
        }

        public IActionResult OnPostDelete(int ODetailes_Id)
        {
            Result result = _service.GetOrderDetails(ODetailes_Id);
            if (result.Success && result.Data is OrderDetails orderDetails)
            {
                _service.DeleteOrderDetails(orderDetails);
                TempData["Msg"] = "Order details deleted successfully.";
            }
            return RedirectToPage();
        }
    }
}