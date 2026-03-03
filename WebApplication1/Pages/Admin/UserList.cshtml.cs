using Business;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin
{
    public class UserListModel(UserService service) : PageModel
    {
        private readonly UserService _service = service;

        public List<User> Users { get; set; } = new();

        public void OnGet()
        {
            Result result = _service.GetAllUser();
            Users = result.Data as List<User> ?? new List<User>();
        }

        public IActionResult OnPostDelete(int id)
        {
            Result getResult = _service.GetUser(id);
            User user = getResult.Data as User ?? new User();
            _service.DeleteUser(user);
            return RedirectToPage("/Admin/UserList");
        }
    }
}