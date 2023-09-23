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
    public class Requests
    {
        [Key]
        public Guid id { get; set; }
        public Guid landlord_id { get; set; }
        public Guid property_id { get; set; }
        public Guid tenant_id { get; set; }
        public Guid? provider_id { get; set; }   
        public string type_of_service { get; set; }
        public string message { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string status { get; set; }

        [Column(TypeName = "date")]
        public DateTime requesteddate_1 { get; set; }

        [Column(TypeName = "date")]
        public DateTime requesteddate_2 { get; set; }

        [Column(TypeName = "date")]
        public DateTime requesteddate_3 { get; set; }
        public string time_1 { get; set; }
        public string time_2 { get; set; }  
        public string time_3 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? accepted_scheduled_date { get; set; }
        public DateTime created_date { get; set; }
    }
}
