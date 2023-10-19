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
    public class ReturnCarController : Controller
    {
        private readonly TheRideYouRentDBContext _context;

        public ReturnCarController(TheRideYouRentDBContext context)
        {
            _context = context;
        }

        // GET: ReturnCar
        public async Task<IActionResult> Index()
        {
            var theRideYouRentDBContext = _context.ReturnCar.Include(r => r.InspectorNoNavigation).Include(r => r.RentalNoNavigation);
            return View(await theRideYouRentDBContext.ToListAsync());
        }

        // GET: ReturnCar/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ReturnCar == null)
            {
                return NotFound();
            }

            var returnCar = await _context.ReturnCar
                .Include(r => r.InspectorNoNavigation)
                .Include(r => r.RentalNoNavigation)
                .FirstOrDefaultAsync(m => m.ReturnId == id);
            if (returnCar == null)
            {
                return NotFound();
            }

            return View(returnCar);
        }

        // GET: ReturnCar/Create
        public IActionResult Create()
        {
            ViewData["InspectorNo"] = new SelectList(_context.Inspector, "InspectorNo", "InspectorNo");
            ViewData["RentalNo"] = new SelectList(_context.Rental, "RentalNo", "RentalNo");
            return View();
        }

        // POST: ReturnCar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // New Create action for creating the ReturnCar entity and calculating the fine
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReturnCar returnCar)
        {
            if (ModelState.IsValid)
            {
                // Calculate the fine based on elapsed days
                int elapsedDays = (int)(DateTime.Now - returnCar.ReturnDate).TotalDays;
                decimal fine = elapsedDays * 500;

                returnCar.ElapsedDate = elapsedDays;
                returnCar.Fine = (double)fine; // Convert decimal to double

                // Perform any additional validation or processing if needed
                // ...

                _context.Add(returnCar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Handle invalid ModelState
            return View(returnCar);
        }


        // GET: ReturnCar/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ReturnCar == null)
            {
                return NotFound();
            }

            var returnCar = await _context.ReturnCar.FindAsync(id);
            if (returnCar == null)
            {
                return NotFound();
            }
            ViewData["InspectorNo"] = new SelectList(_context.Inspector, "InspectorNo", "InspectorNo", returnCar.InspectorNo);
            ViewData["RentalNo"] = new SelectList(_context.Rental, "RentalNo", "RentalNo", returnCar.RentalNo);
            return View(returnCar);
        }

        // POST: ReturnCar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ReturnId,RentalNo,InspectorNo,ReturnDate,ElapsedDate,Fine")] ReturnCar returnCar)
        {
            if (id != returnCar.ReturnId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(returnCar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReturnCarExists(returnCar.ReturnId))
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
            ViewData["InspectorNo"] = new SelectList(_context.Inspector, "InspectorNo", "InspectorNo", returnCar.InspectorNo);
            ViewData["RentalNo"] = new SelectList(_context.Rental, "RentalNo", "RentalNo", returnCar.RentalNo);
            return View(returnCar);
        }

        // GET: ReturnCar/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ReturnCar == null)
            {
                return NotFound();
            }

            var returnCar = await _context.ReturnCar
                .Include(r => r.InspectorNoNavigation)
                .Include(r => r.RentalNoNavigation)
                .FirstOrDefaultAsync(m => m.ReturnId == id);
            if (returnCar == null)
            {
                return NotFound();
            }

            return View(returnCar);
        }

        // POST: ReturnCar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ReturnCar == null)
            {
                return Problem("Entity set 'TheRideYouRentDBContext.ReturnCar'  is null.");
            }
            var returnCar = await _context.ReturnCar.FindAsync(id);
            if (returnCar != null)
            {
                _context.ReturnCar.Remove(returnCar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReturnCarExists(string id)
        {
          return (_context.ReturnCar?.Any(e => e.ReturnId == id)).GetValueOrDefault();
        }
    }
}
