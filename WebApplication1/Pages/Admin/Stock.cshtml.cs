using System.Security.Claims;
using Business;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin
{
    public class StockModel(StockService service) : PageModel
    {
        private readonly StockService _service = service;

        [BindProperty]
        public Stock Model { get; set; } = new();

        public void OnGet(int? Id = null)
        {
            if (Id != null)
            {
                Result result = _service.GetStock(Id.Value);
                Model = result.Data as Stock ?? new Stock();
            }
        }

        public IActionResult OnPost()
        {
            ModelState.Clear();
            Model.Available_Stock = Model.Quantity_In - Model.Quantity_Out;
            Model.UserName = User.FindFirst(ClaimTypes.Name)?.Value ?? string.Empty;

            Result result;
            if (Model.Stock_Id == 0)
                result = _service.AddStock(Model);
            else
                result = _service.UpdateStock(Model);

            if (result.Success)
            {
                TempData["SuccessMessage"] = result.Message;
                return RedirectToPage("/Admin/StockList");
            }
            else
            {
                ModelState.AddModelError("", result.Message);
                return Page();
            }
        }
    }
}