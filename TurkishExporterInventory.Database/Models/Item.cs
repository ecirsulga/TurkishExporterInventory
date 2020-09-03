using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
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

        [MaxLength(500)]
        [AllowNull]
        public string Purpose { get; set; }

        [AllowNull]
        public DateTime BuyingDate { get; set; }

        public virtual ICollection<Allocation> Allocations { get; set; }

        public int rlt_Supplier_Id { get; set; }
        [ForeignKey("rlt_Supplier_Id")]

        public Supplier Supplier { get; set; }

    }
}