using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.FromModel
{
    public class UserLoginFrom
    {
        public class UserLoginForm
        {
            [Required]
            public string? Email { get; set; }
            [Required]
            public string? UserPassword { get; set; }
        }
    }
}
