using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TurkishExporterInventory.Database.Context;
using TurkishExporterInventory.Database.Models;
using TurkishExporterInventory.Models;

namespace TurkishExporterInventory.Controllers
{
    public class ItemController : Controller
    {

        private readonly ILogger<ItemController> _logger;
        private readonly EntityDbContext _entityDbContext;


        public ItemController(ILogger<ItemController> logger, EntityDbContext entityDbContext)
        {
            _logger = logger;
            _entityDbContext = entityDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Itemlist()
        {
            //var items = _entityDbContext.Items.Include(q => q.Allocations);

            var items = _entityDbContext.Items.Select(q => new ItemListModel()
            {
                ItemId = q.Id,
                ItemName = q.Name,
                ItemPrice = q.PriceTL,
                ItemPurpose = q.Purpose,
                ItemBoughtDate = q.BuyingDate,
                ItemBoughtPlace = q.BoughtPlace,
                ItemOwnerNameSurname = q.Allocations.Any(l => l.rlt_Item_Id == q.Id) ? q.Allocations.Where(l => l.rlt_Item_Id == q.Id).Select(s => s.User.Name).ToString() : "",
                ItemOwnersCount = q.Allocations.Count,
                ItemRecordCreateTime = q.RecordCreateTime
            });

            return View(items.ToList());
        }

        public IActionResult ItemAdd()
        {
            return View();
        }
    }
}