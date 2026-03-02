using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Model
{
    public class Notification:BaseModel
    {
       
        [Key]
        public int Notification_Id { get; set; }
        [Required]
        public string AlertEmail { get; set; } = string.Empty;
        [Required]
        public string AlertPhone { get; set; } = string.Empty;
        public int MaxStock { get; set; }
        public int LowStockThreshold { get; set; } = 3;

        [ForeignKey("User")]
        public string P_Name { get; set; } = string.Empty;

        [ForeignKey("User")]
        public int P_Quantity { get; set; }
        public bool IsLowStock => P_Quantity <= LowStockThreshold;

    }
}

