using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Model 
{
    public class Supplier : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SId { get; set; } 

        [Required]
        [StringLength(50)]
        public string SName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string SEmail { get; set; } = string.Empty;

        [Required]
        public int  SNumber { get; set; }

        [Required]
        [StringLength(100)]

        public string SAdress { get; set; }= string.Empty; 
    }
}

