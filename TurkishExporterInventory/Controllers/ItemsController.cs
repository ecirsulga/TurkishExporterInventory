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
                    Price = q.PriceTL,
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
            ViewData["rlt_Supplier_Id"] = new SelectList(_context.Suppliers, "Id", "Name");
            return View();
        }

        // POST: Itemstry/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem([Bind("Name,PriceTL,Purpose,BuyingDate,rlt_Supplier_Id,Id")] Item item)
        {
            item.RecordCreateTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ItemList));
            }
            ViewData["rlt_Supplier_Id"] = new SelectList(_context.Suppliers, "Id", "Id", item.rlt_Supplier_Id);
            return View(item);
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
            ViewData["rlt_Supplier_Id"] = new SelectList(_context.Suppliers, "Id", "Name", item.rlt_Supplier_Id);
            return View(item);
        }

        // POST: Itemstry/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,PriceTL,Purpose,BuyingDate,rlt_Supplier_Id,Id")] Item item)
        {
            item.RecordCreateTime = DateTime.Now;
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
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

            return View(item);
        }

        // POST: Itemstry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.FindAsync(id);
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
