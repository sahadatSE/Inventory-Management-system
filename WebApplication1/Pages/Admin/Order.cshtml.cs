using System.Security.Claims;
using Business;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin
{
    public class OrderModel(OrderService service) : PageModel
    {
        private readonly OrderService _service = service;

        [BindProperty]
        public Order Model { get; set; } = new();

        public void OnGet(int? Id = null)
        {
            if (Id != null)
            {
                Result result = _service.GetOrder(Id.Value);
                Model = result.Data as Order ?? new Order();
            }
        }

        public IActionResult OnPost()
        {
            Model.CreatedBy = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Result result;
            if (Model.O_Id == 0)
                result = _service.AddOrder(Model);
            else
                result = _service.UpdateOrder(Model);

            if (result.Success)
                return RedirectToPage("/Admin/OrderList");
            else
                return Page();
        }
    }
}