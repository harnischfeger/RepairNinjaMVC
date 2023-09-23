using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairNinjaMVC.Data.Entities
{
    public class Categories
    {
        [Key]
        public Guid id { get; set; }
        public string cat_name { get; set; }
        public string cat_itemname { get; set; }
        public string cat_description { get; set; }
    }
}
