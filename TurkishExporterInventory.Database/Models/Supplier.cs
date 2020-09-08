using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using TurkishExporterInventory.Database.Models.Inheritance;

namespace TurkishExporterInventory.Database.Models
{
    public class Supplier : ModelBase
    {
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(10)]
        [AllowNull]
        public string Phone { get; set; }

        [MaxLength(30)]
        [AllowNull]
        public string Email { get; set; }


        public virtual ICollection<Item> Items { get; set; }

    }
}
