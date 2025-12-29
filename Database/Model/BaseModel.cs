using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Model
{
    public class BaseModel
    {
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; }
        [StringLength(128)]
        public string ?CreatedBy { get; set; }
        [StringLength(128)]
        public string ? UpdatedBy { get; set; } 
    }
}
