using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TurkishExporterInventory.Database.Models.Inheritance
{
    public class ModelBase
    {
        [Key]

        public int Id { get; set; }

        public DateTime RecordCreateTime { get; set; }
    }
}
