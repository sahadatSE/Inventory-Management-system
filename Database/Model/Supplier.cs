using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Database.Model 
{
    public class Supplier : BaseModel
    {
        [Key]
        [StringLength(128)]
        public string S_Id { get; set; } = new Guid().ToString();

        [Required]
        [StringLength(50)]
        public string S_Name { get; set; } = string.Empty;

        [Required]

        public int  S_Number { get; set; }

        [Required]
        [StringLength(100)]

        public string S_Adress { get; set; }= string.Empty; 
    }
}

