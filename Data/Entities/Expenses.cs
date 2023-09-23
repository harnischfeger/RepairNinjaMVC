using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairNinjaMVC.Data.Entities
{
    public class Expenses
    {
        [Key] 
        public Guid id { get; set; }
        public Guid landlord_id { get; set; }
        public Guid property_id { get; set; }
        public Guid? provider_id { get; set; }
        public Guid expense_type { get; set; }

        [Column(TypeName = "date")]
        public DateTime? expense_date { get; set; }
        public Guid repair_type { get; set; }
        public decimal amount { get; set; }
        public string? invoice_img { get; set; } 


    }
}
