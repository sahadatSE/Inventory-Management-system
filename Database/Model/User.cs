using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Database.Model
{
    public class User : BaseModel
    {
        [Key]
        [StringLength(128)]
        public string UserId { get; set; } = new Guid().ToString(); 

        [Required]
        [StringLength(100)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public int UserNumber { get; set; }
        [Required]
        public string? UserPassword { get; set; } = string.Empty;

        public int RoleId { get; set; }
    
    }
}
