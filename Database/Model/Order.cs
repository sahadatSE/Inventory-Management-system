using System.ComponentModel.DataAnnotations;

namespace Database.Model
{
    public class Order : BaseModel
    {
        [Key]
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        [StringLength(20)]
        public string OrderStatus { get; set; } = "Pending";

        public decimal TotalAmount { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; } = [];
    }
}