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
        public int Id { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "decimal(18,4)")]

        public Nullable<decimal> Price { get; set; }

        public string Purpose { get; set; }

        public string LastUser { get; set; }

        public int ItemOwnersCount { get; set; }

        public DateTime BoughtDate { get; set; }

        public string BoughtPlace { get; set; }

        public DateTime RecordCreateTime { get; set; }
    }

    
}
