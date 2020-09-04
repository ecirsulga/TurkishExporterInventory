using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TurkishExporterInventory.Database.Models.Inheritance;
namespace TurkishExporterInventory.Database.Models
{
    public class UserListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public int ItemCount { get; set; }

        public List<Item> Items { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public Nullable<decimal> TotalValue { get; set; }
        public string LastItem { get; set; }
        public DateTime RecordCreateTime { get; set; }
    }
}
