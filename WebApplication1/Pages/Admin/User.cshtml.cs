using Business;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin
{
    public class UserModel : PageModel
    {

        [BindProperty]
        public User Model { get; set; } = new();

        public void OnGet(int? Id = null)
        {
            if (Id != null)
            {
                Result result = new UserService().GetUser(Id.Value);
                Model = result.Data as User ?? new User();
            }
        }

        public IActionResult OnPost()
        {
            Result result;

            if (Model.UserId == "0")
                result = new UserService().AddUser(Model);
            else
                result = new UserService().UpdateUser(Model);

            if (result.Success)
                return RedirectToPage("/Admin/UserList");
            else
                return Page();
        }
    }
}

