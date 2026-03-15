using Business;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin
{
    public class SupplierModel(SupplierService service) : PageModel
    {
        private readonly SupplierService _service = service;

        [BindProperty]
        public Supplier Model { get; set; } = new();

        public void OnGet(int? Id = null)
        {
            if (Id != null)
            {
                Result result = _service.GetSupplier(Id.Value);
                Model = result.Data as Supplier ?? new Supplier();
            }
        }

        public IActionResult OnPost()
        {
            ModelState.Clear();

            Result result;

            if (Model.SId == 0)
                result = _service.AddSupplier(Model);
            else
                result = _service.UpdateSupplier(Model);

            if (!result.Success)
            {
                TempData["ErrorMessage"] = result.Message;
                return Page();
            }

            TempData["SuccessMessage"] = result.Message;
            return RedirectToPage("SupplierList");
        }
    }
}