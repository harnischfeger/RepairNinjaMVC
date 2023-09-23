using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairNinjaMVC.Data.Entities
{
    public class Properties
    {
      
        public Guid id { get; set; }
        public Guid landlord_id { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipcode { get; set; }
        public string rent { get; set; }
        public string taxes { get; set; }
        public string mortgage { get; set; }
        public string intial_maint_cost { get; set; }
        public string insurance { get; set; }
        public string hoa { get; set; }
        public DateTime created_date { get; set; }
    }
}
