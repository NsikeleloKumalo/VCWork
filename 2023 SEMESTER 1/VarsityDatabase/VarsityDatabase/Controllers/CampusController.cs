using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VarsityDatabase.Data;
using VarsityDatabase.Models;

namespace VarsityDatabase.Controllers
{
    public class CampusController : Controller
    {
        private readonly DbContextData _context;

        public CampusController(DbContextData context)
        {
            _context = context;
        }

        // GET: Campus
        public async Task<IActionResult> Index()
        {
              return _context.Campus != null ? 
                          View(await _context.Campus.ToListAsync()) :
                          Problem("Entity set 'DbContextData.Campus'  is null.");
        }

        // GET: Campus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Campus == null)
            {
                return NotFound();
            }

            var campusModel = await _context.Campus
                .FirstOrDefaultAsync(m => m.Campus_ID == id);
            if (campusModel == null)
            {
                return NotFound();
            }

            return View(campusModel);
        }

        // GET: Campus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Campus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Campus_ID,Campus_Name,Campus_Address")] CampusModel campusModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(campusModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(campusModel);
        }

        // GET: Campus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Campus == null)
            {
                return NotFound();
            }

            var campusModel = await _context.Campus.FindAsync(id);
            if (campusModel == null)
            {
                return NotFound();
            }
            return View(campusModel);
        }

        // POST: Campus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Campus_ID,Campus_Name,Campus_Address")] CampusModel campusModel)
        {
            if (id != campusModel.Campus_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campusModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampusModelExists(campusModel.Campus_ID))
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
            return View(campusModel);
        }

        // GET: Campus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Campus == null)
            {
                return NotFound();
            }

            var campusModel = await _context.Campus
                .FirstOrDefaultAsync(m => m.Campus_ID == id);
            if (campusModel == null)
            {
                return NotFound();
            }

            return View(campusModel);
        }

        // POST: Campus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Campus == null)
            {
                return Problem("Entity set 'DbContextData.Campus'  is null.");
            }
            var campusModel = await _context.Campus.FindAsync(id);
            if (campusModel != null)
            {
                _context.Campus.Remove(campusModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampusModelExists(int id)
        {
          return (_context.Campus?.Any(e => e.Campus_ID == id)).GetValueOrDefault();
        }
    }
}
