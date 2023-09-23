using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace RepairNinjaMVC.Data.Entities
{
    public class Users
    {
        [Key]
        public Guid id { get; set; }
        public string user_id { get; set; }
        public string password { get; set; }
        public string? email { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string? phone { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipcode { get; set; }
        public DateTime created_date { get; set; }
        public bool is_landlord { get; set; }
        public bool is_tenant { get; set; }
        public bool is_provider { get; set; }
        public bool is_active { get; set; }



    }
}
