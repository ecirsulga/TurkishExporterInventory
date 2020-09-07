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
    public class AllocationsController : Controller
    {
        private readonly EntityDbContext _context;

        public AllocationsController(EntityDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var entityDbContext = _context.Allocations.Include(a => a.Item).Include(a => a.User);
            return View(await entityDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocation = await _context.Allocations
                .Include(a => a.Item)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allocation == null)
            {
                return NotFound();
            }

            return View(allocation);
        }

        public IActionResult Create()
        {
            ViewData["rlt_Item_Id"] = new SelectList(_context.Items, "Id", "Id");
            ViewData["rlt_User_Id"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Information,ItemGivenTime,rlt_User_Id,rlt_Item_Id,Id,RecordCreateTime")] Allocation allocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["rlt_Item_Id"] = new SelectList(_context.Items, "Id", "Id", allocation.rlt_Item_Id);
            ViewData["rlt_User_Id"] = new SelectList(_context.Users, "Id", "Id", allocation.rlt_User_Id);
            return View(allocation);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocation = await _context.Allocations.FindAsync(id);
            if (allocation == null)
            {
                return NotFound();
            }
            ViewData["rlt_Item_Id"] = new SelectList(_context.Items, "Id", "Id", allocation.rlt_Item_Id);
            ViewData["rlt_User_Id"] = new SelectList(_context.Users, "Id", "Id", allocation.rlt_User_Id);
            return View(allocation);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Information,ItemGivenTime,rlt_User_Id,rlt_Item_Id,Id,RecordCreateTime")] Allocation allocation)
        {
            if (id != allocation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllocationExists(allocation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["rlt_Item_Id"] = new SelectList(_context.Items, "Id", "Id", allocation.rlt_Item_Id);
            ViewData["rlt_User_Id"] = new SelectList(_context.Users, "Id", "Id", allocation.rlt_User_Id);
            return View(allocation);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocation = await _context.Allocations
                .Include(a => a.Item)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allocation == null)
            {
                return NotFound();
            }

            return View(allocation);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allocation = await _context.Allocations.FindAsync(id);
            _context.Allocations.Remove(allocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllocationExists(int id)
        {
            return _context.Allocations.Any(e => e.Id == id);
        }
    }
}
