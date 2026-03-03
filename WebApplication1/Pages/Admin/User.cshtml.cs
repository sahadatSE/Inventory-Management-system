// User.cshtml.cs
using System.Security.Claims;
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

        public void OnGet(int? Id = null)
        {
            if (Id != null)
            {
                Result result = _service.GetUser(Id.Value);
                Model = result.Data as User ?? new User();
            }
        }

        public IActionResult OnPost()
        {
            Model.CreatedBy = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Result result;
            if (Model.UserId == null)
                result = _service.AddUser(Model);
            else
                result = _service.UpdateUser(Model);

            if (result.Success)
                return RedirectToPage("/Admin/UserList");
            else
                return Page();
        }
    }
}