using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using TurkishExporterInventory.Database.Models.Inheritance;

namespace TurkishExporterInventory.Database.Models
{
    public class User : ModelBase
    {
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Surname { get; set; }

        public int rlt_Department_Id { get; set; }

        [ForeignKey("rlt_Department_Id")]
        public Department Department { get; set; }

        [AllowNull]
        [MaxLength(50)]
        public string Position { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [AllowNull]
        [MaxLength(10)]
        public string Phone { get; set; }

        [AllowNull]
        [MaxLength(30)]
        public string Email {get;set;}

        public virtual ICollection<Allocation> Allocations { get; set; }

    }
}
