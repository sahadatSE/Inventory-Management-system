using System.Security.Claims;
using Business;
using Business.FromModel;
using Business.Services;
using Database.Context;
using Database.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Business.FromModel.UserLoginFrom;

namespace WebApplication1.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public UserLoginForm loginForm { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var context = new IMSContext();
            Result result = new UserService(context).Login(loginForm);

            if (result.Success)
            {
                User user = result.Data as User;

                var claims = new List<Claim>
                  {
                 new(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                     new(ClaimTypes.Name, user.UserName),  
                     new(ClaimTypes.Role, user.RoleId.ToString())
                  };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToPage("/Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnGetLogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return RedirectToPage("/Index");
        }
    }
}