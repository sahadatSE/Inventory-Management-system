using Business;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin
{
    public class OrderDetailesModel(OrderDetailesService service) : PageModel
    {
        private readonly OrderDetailesService _service = service;

        [BindProperty]
        public OrderDetails Model { get; set; } = new();

        public void OnGet(int? Id = null)
        {
            if (Id != null)
            {
                Result result = _service.GetOrderDetails(Id.Value);
                Model = result.Data as OrderDetails ?? new OrderDetails();
            }
        }

        public IActionResult OnPost()
        {
            Result result;
            if (Model.O_Id == 0)
                result = _service.AddOrderDetails(Model);
            else
                result = _service.UpdateOrderDetails(Model);

            if (result.Success)
                return RedirectToPage("/Admin/OrderDetailesList");
            else
                return Page();
        }
    }
}