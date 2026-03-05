using Business;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin
{
    public class UserModel(UserService service) : PageModel
    {
        private readonly UserService _service = service;

        [BindProperty]
        public User Model { get; set; } = new();

        public void OnGet(string? Id = null)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                Result result = _service.GetUser(int.Parse(Id));
                Model = result.Data as User ?? new User();
            }
        }

        public IActionResult OnPost()
        {
            ModelState.Clear();

            Result result;

           
            bool isNew = string.IsNullOrEmpty(Model.UserId)
                         || Model.UserId == "00000000-0000-0000-0000-000000000000";

            if (isNew)
            {
                Model.UserId = Guid.NewGuid().ToString(); 
                result = _service.AddUser(Model);
            }
            else
            {
                result = _service.UpdateUser(Model);
            }

            if (result.Success)
            {
                TempData["SuccessMessage"] = result.Message;
                return RedirectToPage("/Admin/UserList");
            }
            else
            {
                ModelState.AddModelError("", result.Message);
                return Page();
            }
        }
    }
}