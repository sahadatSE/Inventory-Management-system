using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Database
{
    public class Supplier
    {
        [Key]
        public int S_Id { get; set; }

        [Required]
        public string S_Name { get; set; } = string.Empty;

        [Required]
        public int  S_Number { get; set; }

        [Required]
        public string S_Adress { get; set; }= string.Empty; 
    }
}

