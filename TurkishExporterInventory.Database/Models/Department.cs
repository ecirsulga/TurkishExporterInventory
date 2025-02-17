﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using TurkishExporterInventory.Database.Models.Inheritance;

namespace TurkishExporterInventory.Database.Models
{
    public class Department: ModelBase
    {
        [MaxLength(50)]
        public string Name { get; set; }

        [AllowNull]
        [MaxLength(10)]
        public string Phone { get; set; }

        [AllowNull]
        [MaxLength(30)]
        public string Email { get; set; }


        public virtual ICollection<User> Users { get; set; }
    }
}
