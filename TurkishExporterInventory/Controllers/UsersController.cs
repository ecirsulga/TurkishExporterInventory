﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TurkishExporterInventory.Database.Context;
using TurkishExporterInventory.Database.Models;

namespace TurkishExporterInventory.Controllers
{
    public class UsersController : Controller
    {
        private readonly EntityDbContext _context;

        public UsersController(EntityDbContext context)
        {
            _context = context;

        }

        public IActionResult UserList()
        {
            if (User.Claims.Select(q => q.Value).FirstOrDefault() != null && HttpContext.Session.GetString("UserLoginEmail") == User.Claims.Select(q => q.Value).FirstOrDefault())
            {
                var users = _context.Users.Select(q => new UserListModel()
                {
                    Id = q.Id,
                    Name = q.Name,
                    Surname = q.Surname,
                    Department = q.Department.Name,
                    ItemCount = q.Allocations.Count,
                    Position = q.Position,
                    RecordCreateTime = q.RecordCreateTime,
                    TotalValue = q.Allocations.Where(w => w.rlt_User_Id == q.Id).OrderByDescending(o => o.RecordCreateTime).Select(s => s.Item.PriceTL).Sum() ?? 0,
                    LastItem = q.Allocations.Where(w => w.rlt_User_Id == q.Id).OrderByDescending(o => o.RecordCreateTime).Select(s => s.Item.Name).FirstOrDefault() ?? "Tahsis Yok",
                    Items = q.Allocations.Where(w => w.rlt_User_Id == q.Id).OrderByDescending(o => o.RecordCreateTime).Select(s => s.Item).ToList()
                }); ;


                return View(users.ToList());
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

                var user = await _context.Users
                    .Include(u => u.Department)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (user == null)
                {
                    return NotFound();
                }

                return View(user);
            }
            return RedirectToAction("Logout", "Login");
        }

        public IActionResult AddUser()
        {

            if (User.Claims.Select(q => q.Value).FirstOrDefault() != null && HttpContext.Session.GetString("UserLoginEmail") == User.Claims.Select(q => q.Value).FirstOrDefault())
            {
                ViewData["rlt_Department_Id"] = new SelectList(_context.Departments, "Id", "Name");
                return View();
            }
            return RedirectToAction("Logout", "Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser([Bind("Name,Surname,rlt_Department_Id,Position,Password,Phone,Email,Id")] User user)
        {
            if (User.Claims.Select(q => q.Value).FirstOrDefault() != null && HttpContext.Session.GetString("UserLoginEmail") == User.Claims.Select(q => q.Value).FirstOrDefault())
            {
                user.RecordCreateTime = DateTime.Now;
                if (ModelState.IsValid)
                {
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(UserList));
                }
                ViewData["rlt_Department_Id"] = new SelectList(_context.Departments, "Id", "Id", user.rlt_Department_Id);

                return View(user);
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

                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound();
                }

                ViewData["rlt_Department_Id"] = new SelectList(_context.Departments, "Id", "Name", user.rlt_Department_Id);

                return View(user);
            }
            return RedirectToAction("Logout", "Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Surname,rlt_Department_Id,Position,Password,Phone,Email,Id")] User user)
        {
            if (User.Claims.Select(q => q.Value).FirstOrDefault() != null && HttpContext.Session.GetString("UserLoginEmail") == User.Claims.Select(q => q.Value).FirstOrDefault())
            {
                user.RecordCreateTime = DateTime.Now;
                if (id != user.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(user);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!UserExists(user.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(UserList));
                }

                ViewData["rlt_Department_Id"] = new SelectList(_context.Departments, "Id", "Name", user.rlt_Department_Id);

                return View(user);
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

                var user = await _context.Users
                    .Include(u => u.Department)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (user == null)
                {
                    return NotFound();
                }


                return View(user);
            }
            return RedirectToAction("Logout", "Login");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (User.Claims.Select(q => q.Value).FirstOrDefault() != null && HttpContext.Session.GetString("UserLoginEmail") == User.Claims.Select(q => q.Value).FirstOrDefault())
            {
                var user = await _context.Users.FindAsync(id);
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(UserList));
            }
            return RedirectToAction("Logout", "Login");
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
