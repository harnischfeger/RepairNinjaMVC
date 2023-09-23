using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RepairNinjaMVC.Data.Entities
{
    public class Tenants
    {
        [Key]
        public Guid id { get; set; }
        public Guid property_id { get; set; }
        public string firstname { get; set; }   
        public string lastname { get; set; } 
        public string email { get; set; }
        public string phone { get; set; }
        public Guid landlord_id { get; set; }
    
    }
}
