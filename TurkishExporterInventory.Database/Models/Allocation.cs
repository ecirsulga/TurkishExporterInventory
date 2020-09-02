using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TurkishExporterInventory.Database.Models.Inheritance;

namespace TurkishExporterInventory.Database.Models
{
    public class Allocation : ModelBase
    {
        public string Information { get; set; }

        public DateTime ItemGivenTime { get; set; }

        public int rlt_User_Id { get; set; }

        [ForeignKey("rlt_User_Id")]
        public virtual User User { get; set; }

        public int rlt_Item_Id { get; set; }

        [ForeignKey("rlt_Item_Id")]
        public virtual Item Item { get; set; }
    }
}


