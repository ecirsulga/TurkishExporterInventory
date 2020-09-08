using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
            if (User.Claims.Select(q => q.Value).FirstOrDefault() != null && HttpContext.Session.GetString("UserLoginEmail") == User.Claims.Select(q => q.Value).FirstOrDefault())
            {
                var entityDbContext = _context.Allocations.Include(a => a.Item).Include(a => a.User);

                return View(await entityDbContext.ToListAsync());
            }
            return RedirectToAction("Logout", "Login");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (User.Claims.Select(q => q.Value).FirstOrDefault() != null && HttpContext.Session.GetString("UserLoginEmail") == User.Claims.Select(q => q.Value).FirstOrDefault())
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
            return RedirectToAction("Logout", "Login");
        }

        public IActionResult Create()
        {
            if (User.Claims.Select(q => q.Value).FirstOrDefault() != null && HttpContext.Session.GetString("UserLoginEmail") == User.Claims.Select(q => q.Value).FirstOrDefault())
            {
                ViewData["rlt_Item_Id"] = new SelectList(_context.Items, "Id", "Id");
                ViewData["rlt_User_Id"] = new SelectList(_context.Users, "Id", "Id");

                return View();
            }
            return RedirectToAction("Logout", "Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Information,ItemGivenTime,rlt_User_Id,rlt_Item_Id,Id,RecordCreateTime")] Allocation allocation)
        {
            if (User.Claims.Select(q => q.Value).FirstOrDefault() != null && HttpContext.Session.GetString("UserLoginEmail") == User.Claims.Select(q => q.Value).FirstOrDefault())
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
            return RedirectToAction("Logout", "Login");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (User.Claims.Select(q => q.Value).FirstOrDefault() != null && HttpContext.Session.GetString("UserLoginEmail") == User.Claims.Select(q => q.Value).FirstOrDefault())
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
            return RedirectToAction("Logout", "Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Information,ItemGivenTime,rlt_User_Id,rlt_Item_Id,Id,RecordCreateTime")] Allocation allocation)
        {
            if (User.Claims.Select(q => q.Value).FirstOrDefault() != null && HttpContext.Session.GetString("UserLoginEmail") == User.Claims.Select(q => q.Value).FirstOrDefault())
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
            return RedirectToAction("Logout", "Login");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (User.Claims.Select(q => q.Value).FirstOrDefault() != null && HttpContext.Session.GetString("UserLoginEmail") == User.Claims.Select(q => q.Value).FirstOrDefault())
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
            return RedirectToAction("Logout", "Login");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (User.Claims.Select(q => q.Value).FirstOrDefault() != null && HttpContext.Session.GetString("UserLoginEmail") == User.Claims.Select(q => q.Value).FirstOrDefault())
            {
                var allocation = await _context.Allocations.FindAsync(id);
                _context.Allocations.Remove(allocation);
                await _context.SaveChangesAsync();

                return View(nameof(Index));
            }
            return RedirectToAction("Logout", "Login");
        }

        private bool AllocationExists(int id)
        {
            return _context.Allocations.Any(e => e.Id == id);
        }
    }
}
