using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Order
    {
        [Key]
        public int O_Id { get; set; } 

        public DateTime O_Date { get; set; }= DateTime.Now;

        public int TotalAmmont {  get; set; }

        [ForeignKey("Customer")]
        public int C_Id { get; set; }

    }
}
