using Business;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin
{
    public class OrderDetailesModel : PageModel
    {
        [BindProperty]
        public OrderDetails Model { get; set; } = new();

        public void OnGet(int? Id = null)
        {
            if (Id != null)
            {
                Result result = new OrderDetailesService().GetOrderDetails(Id.Value);
                Model = result.Data as OrderDetails ?? new OrderDetails();
            }
        }

        public IActionResult OnPost()
        {
            Result result;

            if (Model.O_Id == 0)
                result = new OrderDetailesService().AddOrderDetails(Model);
            else
                result = new OrderDetailesService().UpdateOrderDetails(Model);

            if (result.Success)
                return RedirectToPage("/Admin/OrderDetailesList");
            else
                return Page();
        }
    }
}

