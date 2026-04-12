using Business;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Authorization;
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
                Result result = _service.GetUser(Id);
                Model = result.Data as User ?? new User();
            }
        }

        public IActionResult OnPost()
        {
            ModelState.Clear();

           
            Result allUsers = _service.GetAllUser();
            List<User> users = allUsers.Data as List<User> ?? new List<User>();

            bool nameExists = users.Any(u => u.UserName == Model.UserName);
            if (nameExists)
            {
                ModelState.AddModelError("", "Username already exists!");
                return Page();
            }


            bool emailExists = users.Any(u => u.Email == Model.Email);
            if (emailExists)
            {
                ModelState.AddModelError("", "Email already exists!");
                return Page();
            }

            Model.UserId = Guid.NewGuid().ToString();
            Result result2 = _service.AddUser(Model);

            if (result2.Success)
            {
                TempData["SuccessMessage"] = result2.Message;
                return RedirectToPage("/Admin/UserList");
            }
            else
            {
                ModelState.AddModelError("", result2.Message);
                return Page();
            }
        }
    }
}