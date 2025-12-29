using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Database.Model
{
    public class Customer : BaseModel
    {
        [Key]
        [StringLength(128)]
        public string C_Id { get; set; } = new Guid().ToString();   

        [Required]
        [StringLength(100)]
        public string C_Name { get; set; } = string.Empty;

        [Required]
        public int C_Number { get; set; }

        [Required]
        [StringLength(100)]
        public string C_Adress { get; set; } = string.Empty;

    }
}
