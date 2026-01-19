using Business;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin
{
    public class UserListModel : PageModel
    {
        [BindProperty]
        public User model { get; set; } = new();

        public void OnGet(int? Id = null)
        {
            if (Id != null)
            {
                Result result = new UserService().GetUser(Id.Value);
                model = result.Data as User ?? new User();
            }
        }

        public IActionResult OnPost()
        {
            Result result;

         
            if (model.Id == 0)
                result = new UserService().AddUser(model);
            else
                result = new UserService().UpdateUser(model);

            if (result.Success)
                return RedirectToPage("/Admin/UserList");
            else
                return Page();
        }
    }
}

