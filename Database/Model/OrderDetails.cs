using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Model
{
    public class OrderDetails : BaseModel
    {
        [Key]
        public int  ODetailes_Id {  get; set; }

        [ForeignKey("User")]
        
        public string UserID { get; set; } = string.Empty;

        [ForeignKey("Product")]
        public string P_Td { get; set; } = string.Empty;

        [ForeignKey("Discount")]
        public int DiscountId { get; set; }

        [ForeignKey("Offer")]
        public int OfferId { get; set; }





    }
}
