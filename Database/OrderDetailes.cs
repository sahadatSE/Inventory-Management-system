using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database
{
    public class OrderDetailes
    {
        [Key]
        public int  ODetailes_Id {  get; set; }

        [ForeignKey("Customer")]
        public int C_Id { get; set; }

        [ForeignKey("Supplier")]
        public int S_Id { get; set; }


    }
}
