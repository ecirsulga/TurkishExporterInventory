using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TurkishExporterInventory.Database.Models.Inheritance;

namespace TurkishExporterInventory.Database.Models
{
    public class ItemListModel
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        [Column(TypeName = "decimal(18,4)")]

        public Nullable<decimal> ItemPrice { get; set; }

        public string ItemPurpose { get; set; }

        public String ItemOwnerNameSurname { get; set; }

        public int ItemOwnersCount { get; set; }

        public DateTime ItemBoughtDate { get; set; }

        public string ItemBoughtPlace { get; set; }

        public DateTime ItemRecordCreateTime { get; set; }
    }

    
}
