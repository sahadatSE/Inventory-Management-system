using Business;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Pages
{
    public class LoginModel(UserService service) : PageModel
    {
        private readonly UserService _service = service;

        [BindProperty]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("UserId") != null)
                return RedirectToPage("/Admin/UserList");

            return Page();
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                ModelState.AddModelError("", "Email and Password are required!");
                return Page();
            }

           
            Result allResult = _service.GetAllUser();
            List<User> users = allResult.Data as List<User> ?? new List<User>();
            User? user = users.FirstOrDefault(u => u.Email == Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid email or password!");
                return Page();
            }

           
            var hasher = new PasswordHasher<object>();
            var verifyResult = hasher.VerifyHashedPassword(user, user.UserPassword!, Password);

            if (verifyResult == PasswordVerificationResult.Failed)
            {
                ModelState.AddModelError("", "Invalid email or password!");
                return Page();
            }

         
            HttpContext.Session.SetString("UserId", user.UserId!);
            HttpContext.Session.SetString("UserName", user.UserName!);
            HttpContext.Session.SetString("RoleId", user.RoleId.ToString()!);

            return RedirectToPage("/Admin/UserList");
        }
    }
}