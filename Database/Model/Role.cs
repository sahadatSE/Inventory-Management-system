using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Database.Model
{
    [PrimaryKey(nameof(RoleId))]
    public class Role : BaseModel
    {
        public int RoleId { get; set; }
        [StringLength(50)]
        public string RoleName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
