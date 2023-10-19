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
    public class RentalController : Controller
    {
        private readonly TheRideYouRentDBContext _context;

        public RentalController(TheRideYouRentDBContext context)
        {
            _context = context;
        }

        // GET: Rental
        public async Task<IActionResult> Index()
        {
            var theRideYouRentDBContext = _context.Rental.Include(r => r.CarNoNavigation).Include(r => r.Driver).Include(r => r.InspectorNoNavigation);
            return View(await theRideYouRentDBContext.ToListAsync());
        }

        // GET: Rental/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Rental == null)
            {
                return NotFound();
            }

            var rental = await _context.Rental
                .Include(r => r.CarNoNavigation)
                .Include(r => r.Driver)
                .Include(r => r.InspectorNoNavigation)
                .FirstOrDefaultAsync(m => m.RentalNo == id);
            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        // GET: Rental/Create
        public IActionResult Create()
        {
            ViewData["CarNo"] = new SelectList(_context.Car, "CarNo", "CarNo");
            ViewData["DriverId"] = new SelectList(_context.Driver, "DriverId", "DriverId");
            ViewData["InspectorNo"] = new SelectList(_context.Inspector, "InspectorNo", "InspectorNo");
            return View();
        }

        public IActionResult ReturnCarCreate()
        {
            if (TempData["RentalData"] is Rental rentalData)
            {
                ReturnCar returnCar = new ReturnCar
                {
                    RentalNo = rentalData.RentalNo,
                    InspectorNo = rentalData.InspectorNo,
                    ReturnDate = rentalData.EndDate
                };

                return View(returnCar);
            }

            TempData["ErrorMessage"] = "Rental data is missing.";
            return RedirectToAction("Index", "Home"); // Redirect to an appropriate page
        }


        // POST: Rental/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentalNo,RentalFee,StartDate,EndDate,CarNo,InspectorNo,DriverId")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rental);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarNo"] = new SelectList(_context.Car, "CarNo", "CarNo", rental.CarNo);
            ViewData["DriverId"] = new SelectList(_context.Driver, "DriverId", "DriverId", rental.DriverId);
            ViewData["InspectorNo"] = new SelectList(_context.Inspector, "InspectorNo", "InspectorNo", rental.InspectorNo);
            return View(rental);
        }

        // GET: Rental/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Rental == null)
            {
                return NotFound();
            }

            var rental = await _context.Rental.FindAsync(id);
            if (rental == null)
            {
                return NotFound();
            }
            ViewData["CarNo"] = new SelectList(_context.Car, "CarNo", "CarNo", rental.CarNo);
            ViewData["DriverId"] = new SelectList(_context.Driver, "DriverId", "DriverId", rental.DriverId);
            ViewData["InspectorNo"] = new SelectList(_context.Inspector, "InspectorNo", "InspectorNo", rental.InspectorNo);
            return View(rental);
        }

        // POST: Rental/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("RentalNo,RentalFee,StartDate,EndDate,CarNo,InspectorNo,DriverId")] Rental rental)
        {
            if (id != rental.RentalNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rental);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalExists(rental.RentalNo))
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
            ViewData["CarNo"] = new SelectList(_context.Car, "CarNo", "CarNo", rental.CarNo);
            ViewData["DriverId"] = new SelectList(_context.Driver, "DriverId", "DriverId", rental.DriverId);
            ViewData["InspectorNo"] = new SelectList(_context.Inspector, "InspectorNo", "InspectorNo", rental.InspectorNo);
            return View(rental);
        }

        // GET: Rental/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Rental == null)
            {
                return NotFound();
            }

            var rental = await _context.Rental
                .Include(r => r.CarNoNavigation)
                .Include(r => r.Driver)
                .Include(r => r.InspectorNoNavigation)
                .FirstOrDefaultAsync(m => m.RentalNo == id);
            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        // POST: Rental/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Rental == null)
            {
                return Problem("Entity set 'TheRideYouRentDBContext.Rental'  is null.");
            }
            var rental = await _context.Rental.FindAsync(id);
            if (rental != null)
            {
                _context.Rental.Remove(rental);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalExists(string id)
        {
          return (_context.Rental?.Any(e => e.RentalNo == id)).GetValueOrDefault();
        }
    }
}
