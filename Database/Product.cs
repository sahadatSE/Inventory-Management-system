using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Database
{
    public class Product
    {
        [Key]
        public int P_Id { get; set; }

        [Required]
        [StringLength(100)]
        public string P_Name { get; set; } = string.Empty;

        [Range(0, 10000)]
        public int P_Quantity { get; set; }

        [Range(1, 100000)]
        public int P_Price { get; set; }

        [ForeignKey("Supplier")]
        public int S_Id { get; set; } 

    }
}
