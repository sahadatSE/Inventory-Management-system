using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Model
{
    public class Discount:BaseModel
    {
        [Key]
        public int DiscountId { get; set; }

        [Required]
        [StringLength(100)]
        public string DiscountName { get; set; }= string.Empty;

        [Required]
        [Range(0, 100000)]
        public decimal DiscountValue { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
