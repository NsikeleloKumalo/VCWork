using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarketDatabase.Data;
using MarketDatabase.Models;

namespace MarketDatabase.Controllers
{
    public class StoreController : Controller
    {
        private readonly MarketContextData _context;

        public StoreController(MarketContextData context)
        {
            _context = context;
        }

        // GET: Store
        public async Task<IActionResult> Index()
        {
            var marketContextData = _context.Store.Include(s => s.Customer);
            return View(await marketContextData.ToListAsync());
        }

        // GET: Store/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Store == null)
            {
                return NotFound();
            }

            var storeModel = await _context.Store
                .Include(s => s.Customer)
                .FirstOrDefaultAsync(m => m.Store_Id == id);
            if (storeModel == null)
            {
                return NotFound();
            }

            return View(storeModel);
        }

        // GET: Store/Create
        public IActionResult Create()
        {
            ViewData["Customer_Id"] = new SelectList(_context.Customer, "Customer_Id", "Customer_Id");
            return View();
        }

        // POST: Store/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Store_Id,StoreName,Date_Creation,Customer_Id")] StoreModel storeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Customer_Id"] = new SelectList(_context.Customer, "Customer_Id", "Customer_Id", storeModel.Customer_Id);
            return View(storeModel);
        }

        // GET: Store/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Store == null)
            {
                return NotFound();
            }

            var storeModel = await _context.Store.FindAsync(id);
            if (storeModel == null)
            {
                return NotFound();
            }
            ViewData["Customer_Id"] = new SelectList(_context.Customer, "Customer_Id", "Customer_Id", storeModel.Customer_Id);
            return View(storeModel);
        }

        // POST: Store/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Store_Id,StoreName,Date_Creation,Customer_Id")] StoreModel storeModel)
        {
            if (id != storeModel.Store_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoreModelExists(storeModel.Store_Id))
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
            ViewData["Customer_Id"] = new SelectList(_context.Customer, "Customer_Id", "Customer_Id", storeModel.Customer_Id);
            return View(storeModel);
        }

        // GET: Store/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Store == null)
            {
                return NotFound();
            }

            var storeModel = await _context.Store
                .Include(s => s.Customer)
                .FirstOrDefaultAsync(m => m.Store_Id == id);
            if (storeModel == null)
            {
                return NotFound();
            }

            return View(storeModel);
        }

        // POST: Store/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Store == null)
            {
                return Problem("Entity set 'MarketContextData.Store'  is null.");
            }
            var storeModel = await _context.Store.FindAsync(id);
            if (storeModel != null)
            {
                _context.Store.Remove(storeModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoreModelExists(int id)
        {
          return (_context.Store?.Any(e => e.Store_Id == id)).GetValueOrDefault();
        }
    }
}
