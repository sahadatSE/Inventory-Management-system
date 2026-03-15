using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Model
{
    public class Product : BaseModel
    {
        [Key]
        public int PId { get; set; }

        [Required]
        [StringLength(100)]
        public string PName { get; set; } = string.Empty;

        [Required]
        [Range(0, 10000)]
        public int PQuantity { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; } = string.Empty;

        [Range(0, 100000)]
        public decimal PPrice { get; set; }

       
        public int SupplierId { get; set; }

        [ForeignKey("SupplierId")]
        public Supplier? Supplier { get; set; }
    }
}