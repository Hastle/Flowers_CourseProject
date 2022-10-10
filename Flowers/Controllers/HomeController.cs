using Flowers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Flowers.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Shops.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Shop shop)
        {
            db.Shops.Add(shop);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Shop shop = await db.Shops.FirstOrDefaultAsync(p => p.Id == id);
                if (shop != null)
                    return View(shop);
            }
            return NotFound();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Shop shop = await db.Shops.FirstOrDefaultAsync(p => p.Id == id);
                if (shop != null)
                    return View(shop);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Shop shop)
        {
            db.Shops.Update(shop);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Shop shop = await db.Shops.FirstOrDefaultAsync(p => p.Id == id);
                if (shop != null)
                    return View(shop);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Shop shop = new Shop { Id = id.Value };
                db.Entry(shop).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        public async Task<IActionResult> Products()
        {
            return View(await db.Shops.ToListAsync());
        }

    }
}
