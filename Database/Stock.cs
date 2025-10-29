using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database
{
    internal class Stock
    {
        [Key]
        public int Stock_Id { get; set; }

        [Required]  
        public int Quantity_In {  get; set; }   

        [Required]
        public int Quantity_Out { get; set; }

        public int Available_Stock {  get; set; }

        [ForeignKey("Product")]
        public int P_Id { get; set; }

    }
}
