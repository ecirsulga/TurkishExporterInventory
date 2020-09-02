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
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserDepartment { get; set; }
        public string UserPosition { get; set; }
        public int UserItemCount { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public Nullable<decimal> UserTotalValue { get; set; }
        public int UserLastItem { get; set; }
        public DateTime UserRecordCreateTime { get; set; }
    }
}
