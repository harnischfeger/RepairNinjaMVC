using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairNinjaMVC.Data.Entities
{
    public class Provider_Details
    {
        [Key]
        public Guid id { get; set; }
        public bool? is_hvac { get; set; }
        public bool? is_plumbing { get; set; }
        public bool? is_electric { get; set; }
        public bool? is_roofing { get; set; }
        public bool? is_gutterpowerwash { get; set; }
        public bool? is_general { get; set; }
        public string service_area { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
