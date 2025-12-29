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

        [ForeignKey("Customer")]
        [StringLength(128)]

        public string C_Id { get; set; } = string.Empty;

        [ForeignKey("Supplier")]
        public int S_Id { get; set; }


    }
}
