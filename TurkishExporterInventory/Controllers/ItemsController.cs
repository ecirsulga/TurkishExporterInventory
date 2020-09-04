using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TurkishExporterInventory.Database.Context;
using TurkishExporterInventory.Database.Models;

namespace TurkishExporterInventory.Controllers
{
    public class ItemsController : Controller
    {
        private readonly EntityDbContext _context;

        public ItemsController(EntityDbContext context)
        {
            _context = context;
        }

        // GET: Items
        public IActionResult ItemList()
        {
            //var items = _entityDbContext.Items.Include(q => q.Allocations);



            var items = _context.Items.
                Select(q => new ItemListModel()

                {
                    Id = q.Id,
                    Name = q.Name,
                    PriceTL = q.PriceTL,
                    Purpose = q.Purpose,
                    BoughtDate = q.BuyingDate,
                    BoughtPlace = q.Supplier.Name,
                    LastUser = q.Allocations.Where(w => w.rlt_Item_Id == q.Id).OrderByDescending(o => o.RecordCreateTime).Select(s => s.User.Name + " " + s.User.Surname).FirstOrDefault() ?? "Tahsis Yok",
                    ItemOwnersCount = q.Allocations.Count,
                    RecordCreateTime = q.RecordCreateTime
                }) ;



            return View(items.ToList());
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Itemstry/Create
        public IActionResult AddItem()
        {
            var userselect = _context.Users.Select(x =>
            new
            {
                Id = x.Id,
                Name = x.Name + " " + x.Surname
            });

            ViewData["rlt_Supplier_Id"] = new SelectList(_context.Suppliers, "Id", "Name");
            ViewData["rlt_User_Id"] = new SelectList(userselect, "Id", "Name", 0).Append(new SelectListItem("Şimdilik kimseye verilmeyecek.", "0")).OrderBy(i => i.Value);
            return View();
        }

        // POST: Itemstry/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult AddItem(ItemListModel item)
        {
         

        
            
            if (ModelState.IsValid)
            {
                using (EntityDbContext entity = _context)
                {
                    var itemModel = new Item();
                    itemModel.Id = item.Id;
                    itemModel.Name = item.Name;
                    itemModel.PriceTL = item.PriceTL;
                    itemModel.Purpose = item.Purpose;
                    itemModel.RecordCreateTime = DateTime.Now;
                    itemModel.rlt_Supplier_Id = item.rlt_Supplier_Id;

                    _context.Items.Add(itemModel);
                    _context.SaveChanges();

                    int id = itemModel.Id;

                    if (item.rlt_User_Id !=0 )
                    {
                        var allocation = new Allocation();
                        allocation.ItemGivenTime = DateTime.Now;
                        allocation.RecordCreateTime = DateTime.Now;
                        allocation.rlt_Item_Id = id;
                        allocation.rlt_User_Id = item.rlt_User_Id;
                        _context.Allocations.Add(allocation);
                        _context.SaveChanges();
                    }
                    
                }

                
                

                
                return RedirectToAction(nameof(ItemList));
            }
            ViewData["rlt_User_Id"] = new SelectList(_context.Users, "Id", "Name");
            ViewData["rlt_Supplier_Id"] = new SelectList(_context.Suppliers, "Id", "Name", item.rlt_Supplier_Id);
            return View();
        }

        // GET: Itemstry/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ItemListModel sendmodel = new ItemListModel();
            var rlt_User_Id = _context.Allocations.Where(q => q.rlt_Item_Id == id).OrderByDescending(i => i.ItemGivenTime).Select(q => q.rlt_User_Id).FirstOrDefault();

            sendmodel.Id = item.Id;
            sendmodel.Name = item.Name;
            sendmodel.PriceTL = item.PriceTL;
            sendmodel.Purpose = item.Purpose;
            sendmodel.BuyingDate = item.BuyingDate;
            sendmodel.rlt_Supplier_Id = item.rlt_Supplier_Id;
            sendmodel.rlt_User_Id = rlt_User_Id;

            var userselect = _context.Users.Select(x =>
            new
            {
                Id = x.Id,
                Name = x.Name + " " + x.Surname
            });

            ViewData["rlt_Supplier_Id"] = new SelectList(_context.Suppliers, "Id", "Name", item.rlt_Supplier_Id);
            ViewData["rlt_User_Id"] = new SelectList(userselect, "Id", "Name", sendmodel.rlt_User_Id).Append(new SelectListItem("Daha önce kimseye tahsis edilmedi.", "0"));
            return View(sendmodel);
        }

        // POST: Itemstry/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ItemListModel itemmodel)
        {
            Item item = new Item();
            item.Id = itemmodel.Id;
            item.Name = itemmodel.Name;
            item.PriceTL = itemmodel.PriceTL;
            item.Purpose = itemmodel.Purpose;
            item.BuyingDate = itemmodel.BuyingDate;
            item.rlt_Supplier_Id = itemmodel.rlt_Supplier_Id;

            item.RecordCreateTime = DateTime.Now;
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Items.Update(item);
                    await _context.SaveChangesAsync();
                    if (itemmodel.rlt_User_Id != 0)
                    {
                        var allocation = new Allocation();
                        
                        allocation.ItemGivenTime = DateTime.Now;
                        allocation.RecordCreateTime = DateTime.Now;
                        allocation.rlt_Item_Id = id;
                        allocation.rlt_User_Id = itemmodel.rlt_User_Id;
                        _context.Allocations.Add(allocation);
                        _context.SaveChanges();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ItemList));
            }
            ViewData["rlt_Supplier_Id"] = new SelectList(_context.Suppliers, "Id", "Id", item.rlt_Supplier_Id);
            return View(item);
        }

        // GET: Itemstry/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            item = await _context.Items.FindAsync(id);
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ItemList));
            
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
    }
}
