using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Company.Data;
using Company.Models;

namespace Company.Controllers
{
    public class StoreController : Controller
    {
        private readonly CompanyDatabase _context;

        public StoreController(CompanyDatabase context)
        {
            _context = context;
        }

        // GET: Store
        public async Task<IActionResult> Index()
        {
            var companyDatabase = _context.Store.Include(s => s.Customer).Include(s => s.Employee);
            return View(await companyDatabase.ToListAsync());
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
                .Include(s => s.Employee)
                .FirstOrDefaultAsync(m => m.StoreID == id);
            if (storeModel == null)
            {
                return NotFound();
            }

            return View(storeModel);
        }

        // GET: Store/Create
        public IActionResult Create()
        {
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerId", "CustomerId");
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID");
            return View();
        }

        // POST: Store/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StoreID,StoreName,CustomerID,EmployeeID")] StoreModel storeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", storeModel.CustomerID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID", storeModel.EmployeeID);
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
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", storeModel.CustomerID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID", storeModel.EmployeeID);
            return View(storeModel);
        }

        // POST: Store/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StoreID,StoreName,CustomerID,EmployeeID")] StoreModel storeModel)
        {
            if (id != storeModel.StoreID)
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
                    if (!StoreModelExists(storeModel.StoreID))
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
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", storeModel.CustomerID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID", storeModel.EmployeeID);
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
                .Include(s => s.Employee)
                .FirstOrDefaultAsync(m => m.StoreID == id);
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
                return Problem("Entity set 'CompanyDatabase.StoreModels'  is null.");
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
          return (_context.Store?.Any(e => e.StoreID == id)).GetValueOrDefault();
        }
    }
}
