using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Model
{
    public class OrderDetails : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int OrderDetailsId { get; set; }              

        [ForeignKey("Order")]
        public string OrderId { get; set; } = string.Empty;
        public Order? Order { get; set; }

        [ForeignKey("Product")]
        public int PId { get; set; }
        public Product? Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        [NotMapped]
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}