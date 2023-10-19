using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cldv6211TheRideYouRent.Data;
using cldv6211TheRideYouRent.Models;

namespace cldv6211TheRideYouRent.Controllers
{
    public class InspectorController : Controller
    {
        private readonly TheRideYouRentDBContext _context;

        public InspectorController(TheRideYouRentDBContext context)
        {
            _context = context;
        }

        // GET: Inspector
        public async Task<IActionResult> Index()
        {
              return _context.Inspector != null ? 
                          View(await _context.Inspector.ToListAsync()) :
                          Problem("Entity set 'TheRideYouRentDBContext.Inspector'  is null.");
        }

        // GET: Inspector/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Inspector == null)
            {
                return NotFound();
            }

            var inspector = await _context.Inspector
                .FirstOrDefaultAsync(m => m.InspectorNo == id);
            if (inspector == null)
            {
                return NotFound();
            }

            return View(inspector);
        }

        // GET: Inspector/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inspector/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InspectorNo,InspectorName,InspectorEmail,InspectorMobile")] Inspector inspector)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inspector);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inspector);
        }

        // GET: Inspector/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Inspector == null)
            {
                return NotFound();
            }

            var inspector = await _context.Inspector.FindAsync(id);
            if (inspector == null)
            {
                return NotFound();
            }
            return View(inspector);
        }

        // POST: Inspector/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("InspectorNo,InspectorName,InspectorEmail,InspectorMobile")] Inspector inspector)
        {
            if (id != inspector.InspectorNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inspector);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InspectorExists(inspector.InspectorNo))
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
            return View(inspector);
        }

        // GET: Inspector/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Inspector == null)
            {
                return NotFound();
            }

            var inspector = await _context.Inspector
                .FirstOrDefaultAsync(m => m.InspectorNo == id);
            if (inspector == null)
            {
                return NotFound();
            }

            return View(inspector);
        }

        // POST: Inspector/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Inspector == null)
            {
                return Problem("Entity set 'TheRideYouRentDBContext.Inspector'  is null.");
            }
            var inspector = await _context.Inspector.FindAsync(id);
            if (inspector != null)
            {
                _context.Inspector.Remove(inspector);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InspectorExists(string id)
        {
          return (_context.Inspector?.Any(e => e.InspectorNo == id)).GetValueOrDefault();
        }
    }
}
