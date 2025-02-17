﻿using System;
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
            if (User.Claims.Select(q => q.Value).FirstOrDefault() != null && HttpContext.Session.GetString("UserLoginEmail") == User.Claims.Select(q => q.Value).FirstOrDefault())
            {
                //var items = _entityDbContext.Items.Include(q => q.Allocations);



                var items = _context.Items.
                    Select(q => new ItemListModel()

                    {
                        Id = q.Id,
                        Name = q.Name,
                        PriceTL = q.PriceTL,
                        Purpose = q.Purpose,
                        BuyingDate = q.BuyingDate,
                        BoughtPlace = q.Supplier.Name,
                        LastUserName = q.Allocations.Where(w => w.rlt_Item_Id == q.Id).OrderByDescending(o => o.RecordCreateTime).Select(s => s.User.Name + " " + s.User.Surname).FirstOrDefault() ?? "Tahsis Yok",
                        ItemOwnersCount = q.Allocations.Count,
                        RecordCreateTime = q.RecordCreateTime
                    });


                return View(items.ToList());
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

                var item = await _context.Items
                    .FirstOrDefaultAsync(m => m.Id == id);
                var itemModel = new ItemListModel();
                itemModel.Id = item.Id;
                itemModel.Name = item.Name;
                itemModel.PriceTL = item.PriceTL;
                itemModel.Purpose = item.Purpose;
                itemModel.RecordCreateTime = DateTime.Now;
                itemModel.rlt_Supplier_Id = item.rlt_Supplier_Id;
                itemModel.BuyingDate = item.BuyingDate;
                itemModel.LastUserName = _context.Allocations.Where(w => w.rlt_Item_Id == id).OrderByDescending(o => o.RecordCreateTime).Select(s => s.User.Name + " " + s.User.Surname).FirstOrDefault() ?? null;
                if(item.ReturnDate!=null)
                    itemModel.ReturnDate = (DateTime)item.ReturnDate;
                if (item == null)
                {
                    return NotFound();
                }

                return View(itemModel);
            }
            return RedirectToAction("Logout", "Login");
        }

        public IActionResult AddItem()
        {
            if (User.Claims.Select(q => q.Value).FirstOrDefault() != null && HttpContext.Session.GetString("UserLoginEmail") == User.Claims.Select(q => q.Value).FirstOrDefault())
            {
                var userselect = _context.Users.Select(x =>
                new
                {
                    Id = x.Id,
                    Name = x.Name + " " + x.Surname
                });

                ViewData["rlt_Supplier_Id"] = new SelectList(_context.Suppliers, "Id", "Name").Append(new SelectListItem("Yeni Tedarikçi Ekle", "0"));
                ViewData["rlt_User_Id"] = new SelectList(userselect, "Id", "Name", 0).Append(new SelectListItem("Şimdilik kimseye verilmeyecek.", "0")).OrderBy(i => i.Value);
                return View();
            }
            return RedirectToAction("Logout", "Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddItem(ItemListModel item)
        {
            if (User.Claims.Select(q => q.Value).FirstOrDefault() != null && HttpContext.Session.GetString("UserLoginEmail") == User.Claims.Select(q => q.Value).FirstOrDefault())
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

                        if (item.rlt_Supplier_Id == 0)
                        {
                            var supplier = new Supplier();
                            supplier.RecordCreateTime = DateTime.Now;
                            supplier.Name = item.Supplier.Name;
                            supplier.Phone = item.Supplier.Phone;
                            supplier.Email = item.Supplier.Email;
                            _context.Suppliers.Add(supplier);
                            _context.SaveChanges();
                            itemModel.rlt_Supplier_Id = supplier.Id;
                        }
                        else
                        {
                            itemModel.rlt_Supplier_Id = item.rlt_Supplier_Id;
                        }
                        itemModel.BuyingDate = item.BuyingDate;
                        _context.Items.Add(itemModel);
                        _context.SaveChanges();

                        int id = itemModel.Id;

                        if (item.rlt_User_Id != 0)
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
                ViewData["rlt_Supplier_Id"] = new SelectList(_context.Suppliers, "Id", "Name");
                return View();
            }
            return RedirectToAction("Logout", "Login");

        }

        public IActionResult Edit(int? id)
        {
            if (User.Claims.Select(q => q.Value).FirstOrDefault() != null && HttpContext.Session.GetString("UserLoginEmail") == User.Claims.Select(q => q.Value).FirstOrDefault())
            {
                if (id == null)
                {
                    return NotFound();
                }
                var item = _context.Items.Find(id);
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


                sendmodel.LastUserName = _context.Allocations.Where(w => w.rlt_Item_Id == id).OrderByDescending(o => o.RecordCreateTime).Select(s => s.User.Name + " " + s.User.Surname).FirstOrDefault() ?? null;
                if (sendmodel.LastUserName != null)
                {
                    sendmodel.ReturnDate = DateTime.Now;
                }
                sendmodel.LastUserId = _context.Allocations.Where(w => w.rlt_Item_Id == id).OrderByDescending(o => o.RecordCreateTime).Select(s => s.User.Id).FirstOrDefault();

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
            return RedirectToAction("Logout", "Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ItemListModel itemmodel)
        {
            if (User.Claims.Select(q => q.Value).FirstOrDefault() != null && HttpContext.Session.GetString("UserLoginEmail") == User.Claims.Select(q => q.Value).FirstOrDefault())
            {
                Item item = new Item();
                item.Id = itemmodel.Id;
                item.Name = itemmodel.Name;
                item.PriceTL = itemmodel.PriceTL;
                item.Purpose = itemmodel.Purpose;
                item.BuyingDate = itemmodel.BuyingDate;
                item.rlt_Supplier_Id = itemmodel.rlt_Supplier_Id;
                if (itemmodel.ReturnDate != null)
                {
                    item.ReturnDate = itemmodel.ReturnDate;
                }

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

                var item = await _context.Items
                    .Include(u => u.Supplier)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (item == null)
                {
                    return NotFound();
                }


                return View(item);
            }
            return RedirectToAction("Logout", "Login");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (User.Claims.Select(q => q.Value).FirstOrDefault() != null && HttpContext.Session.GetString("UserLoginEmail") == User.Claims.Select(q => q.Value).FirstOrDefault())
            {
                var item = await _context.Items.FindAsync(id);
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(ItemList));
            }
            return RedirectToAction("Logout", "Login");
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
    }
}
