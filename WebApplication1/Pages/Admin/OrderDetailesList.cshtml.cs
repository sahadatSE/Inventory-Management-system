using Business;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace WebApplication1.Pages.Admin
{
    public class OrderDetailesListModel : PageModel
    {
        public List<OrderDetails> OrderDetails { get; set; } = [];

        public void OnGet()
        {
            Result result = new OrderDetailesService().GetAllOrderDetails();
            OrderDetails = result.Data as List<OrderDetails> ?? [];
        }

        public IActionResult OnPostDelete(int ODetailes_Id)
        {
            var service = new OrderDetailesService();
            Result result = service.GetOrderDetails(ODetailes_Id);

            if (result.Success && result.Data is OrderDetails orderDetails)
            {
                service.DeleteOrderDetails(orderDetails);
                TempData["Msg"] = "Order details deleted successfully.";
            }

            return RedirectToPage();
        }
    }
}

