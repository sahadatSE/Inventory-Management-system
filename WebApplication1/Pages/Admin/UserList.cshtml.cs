using Business;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin
{
    [Authorize(Roles = "1")]
    public class UserListModel(UserService service) : PageModel
    {
        private readonly UserService _service = service;
        public List<User> Users { get; set; } = new();

        public void OnGet()
        {
            Result result = _service.GetAllUser();
            Users = result.Data as List<User> ?? new List<User>();
        }

        public IActionResult OnPostDelete(string id)
        {
            
            Result getResult = _service.GetUser(id);
            if (!getResult.Success)
            {
                TempData["ErrorMessage"] = "User not found";
                return RedirectToPage();
            }

            
            User user = getResult.Data as User ?? new User();
            Result result = _service.DeleteUser(user);

            if (result.Success)
                TempData["SuccessMessage"] = result.Message;
            else
                TempData["ErrorMessage"] = result.Message;

            return RedirectToPage();
        }
    }
}