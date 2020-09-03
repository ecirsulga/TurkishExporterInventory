using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TurkishExporterInventory.Database.Models;

namespace TurkishExporterInventory.Database.Context
{
    public class EntityDbContext : DbContext
    {
        

        public EntityDbContext(DbContextOptions<EntityDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }


        #region Tables

        public virtual DbSet<Item> Items { get; set; } // Eşyaların/Ürünlerin tutulduğu Tablo
        public virtual DbSet<User> Users { get; set; } // Çalışanların tutulduğu tablo
        public virtual DbSet<Allocation> Allocations { get; set; } // Emanet vermelerin tutulduğu tablo
        public virtual DbSet<Department> Departments { get; set; }

        #endregion
    }
}
