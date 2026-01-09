using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Model
{
    public class Order : BaseModel
    {
        [Key]
        public int O_Id { get; set; }

        public DateTime O_Date { get; set; } = DateTime.UtcNow;

        public int TotalAmmont { get; set; }

        [ForeignKey("User")]
        public string UserID { get; set; } = string.Empty;

        [ForeignKey("Product")]
        public string P_Id { get; set; } = string.Empty;

        [ForeignKey("Product")]
        public int P_Quantity { get; set; }


    }
}
