using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Model
{
    public class Order : BaseModel
    {
        [Key]
        public int OrderId { get; set; }


        public string? UserId { get; set; }

        [ForeignKey("UserId")]
        public Database.Model.User? User { get; set; }

        [StringLength(100)]
        public string? CustomerName { get; set; }

        [StringLength(150)]
        public string? CustomerEmail { get; set; }

        [StringLength(11)]
        public string? CustomerPhone { get; set; }

        [StringLength(250)]
        public string? CustomerAddress { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        [StringLength(20)]
        public string OrderStatus { get; set; } = "Pending";

        public decimal TotalAmount { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; } = [];
    }
}