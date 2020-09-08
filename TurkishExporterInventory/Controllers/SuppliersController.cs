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
    public class SuppliersController : Controller
    {
        private readonly EntityDbContext _context;

        public SuppliersController(EntityDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            if (User.Claims.Select(q => q.Value).FirstOrDefault() != null && HttpContext.Session.GetString("UserLoginEmail") == User.Claims.Select(q => q.Value).FirstOrDefault())
            {
                return View(await _context.Suppliers.ToListAsync());
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

                var supplier = await _context.Suppliers
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (supplier == null)
                {
                    return NotFound();
                }

                return View(supplier);
            }
            return RedirectToAction("Logout", "Login");
        }

        public IActionResult Create()
        {
            if (User.Claims.Select(q => q.Value).FirstOrDefault() != null && HttpContext.Session.GetString("UserLoginEmail") == User.Claims.Select(q => q.Value).FirstOrDefault())
            {
                return View();
            }
            return RedirectToAction("Logout", "Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Phone,Email,Id")] Supplier supplier)
        {
            if (User.Claims.Select(q => q.Value).FirstOrDefault() != null && HttpContext.Session.GetString("UserLoginEmail") == User.Claims.Select(q => q.Value).FirstOrDefault())
            {
                supplier.RecordCreateTime = DateTime.Now;
                if (ModelState.IsValid)
                {
                    _context.Add(supplier);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                return View(supplier);
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

                var supplier = await _context.Suppliers.FindAsync(id);
                if (supplier == null)
                {
                    return NotFound();
                }

                return View(supplier);
            }
            return RedirectToAction("Logout", "Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Phone,Email,Id")] Supplier supplier)
        {
            if (User.Claims.Select(q => q.Value).FirstOrDefault() != null && HttpContext.Session.GetString("UserLoginEmail") == User.Claims.Select(q => q.Value).FirstOrDefault())
            {
                supplier.RecordCreateTime = DateTime.Now;
                if (id != supplier.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(supplier);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!SupplierExists(supplier.Id))
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

                return View(supplier);
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

                var supplier = await _context.Suppliers
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (supplier == null)
                {
                    return NotFound();
                }

                return View(supplier);
            }
            return RedirectToAction("Logout", "Login");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (User.Claims.Select(q => q.Value).FirstOrDefault() != null && HttpContext.Session.GetString("UserLoginEmail") == User.Claims.Select(q => q.Value).FirstOrDefault())
            {
                var supplier = await _context.Suppliers.FindAsync(id);
                _context.Suppliers.Remove(supplier);
                await _context.SaveChangesAsync();

                return View(nameof(Index));
            }
            return RedirectToAction("Logout", "Login");
        }

        private bool SupplierExists(int id)
        {
            return _context.Suppliers.Any(e => e.Id == id);
        }
    }
}
