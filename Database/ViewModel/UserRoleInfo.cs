using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Database.ViewModel
{
    [PrimaryKey(nameof(RoleId), nameof(C_Id))]
    public class UserRoleInfo
    {
        public string C_Id { get; set; } = string.Empty;   //Chumtu unique identifier
        public string C_Name { get; set; } = string.Empty;
        public int C_Number { get; set; }
        public string C_Adress { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
    }
}
