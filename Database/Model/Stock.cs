using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Model
{
    public class Stock : BaseModel
    {
        [Key]
        public int Stock_Id { get; set; }

        [Required]
        public int Quantity_In { get; set; }

        [Required]
        public int Quantity_Out { get; set; }

        public int Available_Stock => Quantity_In - Quantity_Out;

        [Range(0, 100000)]
        public decimal Price { get; set; }

        [StringLength(50)]
        public string Category { get; set; } = string.Empty;

        [ForeignKey("Product")]
        public int P_Id { get; set; }
        public Product? Product { get; set; }

        public string UserName { get; set; } = string.Empty;

        public DateTime EntryDate { get; set; } = DateTime.UtcNow;
    }
}