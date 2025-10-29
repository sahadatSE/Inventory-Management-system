using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Database
{
    public class Customer
    {
        [Key]
        public int C_Id { get; set; }

        [Required]
        [StringLength(100)]
        public string C_Name { get; set; } = string.Empty;

        [Required]
        public int C_Number { get; set; }

        [Required]
        public string C_Adress { get; set; } = string.Empty;

    }
}
