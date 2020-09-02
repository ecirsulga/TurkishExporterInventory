using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TurkishExporterInventory.Database.Models.Inheritance;

namespace TurkishExporterInventory.Database.Models
{
    public class Item : ModelBase
    {
        [MaxLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,4)")]

        public Nullable<decimal> PriceTL { get; set; }

        [MaxLength(100)]
        public string BoughtPlace { get; set; }

        [MaxLength(500)]
        public string Purpose { get; set; }

        public DateTime BuyingDate { get; set; }

        public virtual ICollection<Allocation> Allocations { get; set; }

    }
}