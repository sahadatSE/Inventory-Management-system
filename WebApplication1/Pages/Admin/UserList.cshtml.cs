using Business;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin
{
    public class UserListModel(UserService service) : PageModel
    {
        private readonly UserService _service = service;

        public List<User> List { get; set; } = new();

        public void OnGet()
        {
            Result result = _service.GetAllUser();  
            if (result.Success)
            {
                List = result.Data as List<User> ?? new List<User>();
            }
        }
    }
}