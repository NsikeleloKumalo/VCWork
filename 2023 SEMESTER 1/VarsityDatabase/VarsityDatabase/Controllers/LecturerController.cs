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
    public class LecturerController : Controller
    {
        private readonly DbContextData _context;

        public LecturerController(DbContextData context)
        {
            _context = context;
        }

        // GET: Lecturer
        public async Task<IActionResult> Index()
        {
              return _context.Lecturer != null ? 
                          View(await _context.Lecturer.ToListAsync()) :
                          Problem("Entity set 'DbContextData.Lecturer'  is null.");
        }

        // GET: Lecturer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lecturer == null)
            {
                return NotFound();
            }

            var lecturerModel = await _context.Lecturer
                .FirstOrDefaultAsync(m => m.Lecturer_ID == id);
            if (lecturerModel == null)
            {
                return NotFound();
            }

            return View(lecturerModel);
        }

        // GET: Lecturer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lecturer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Lecturer_ID,Lecturer_Name,Lecturer_Surname,Lecturer_Email,Lecturer_Module")] LecturerModel lecturerModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lecturerModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lecturerModel);
        }

        // GET: Lecturer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lecturer == null)
            {
                return NotFound();
            }

            var lecturerModel = await _context.Lecturer.FindAsync(id);
            if (lecturerModel == null)
            {
                return NotFound();
            }
            return View(lecturerModel);
        }

        // POST: Lecturer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Lecturer_ID,Lecturer_Name,Lecturer_Surname,Lecturer_Email,Lecturer_Module")] LecturerModel lecturerModel)
        {
            if (id != lecturerModel.Lecturer_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lecturerModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LecturerModelExists(lecturerModel.Lecturer_ID))
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
            return View(lecturerModel);
        }

        // GET: Lecturer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lecturer == null)
            {
                return NotFound();
            }

            var lecturerModel = await _context.Lecturer
                .FirstOrDefaultAsync(m => m.Lecturer_ID == id);
            if (lecturerModel == null)
            {
                return NotFound();
            }

            return View(lecturerModel);
        }

        // POST: Lecturer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lecturer == null)
            {
                return Problem("Entity set 'DbContextData.Lecturer'  is null.");
            }
            var lecturerModel = await _context.Lecturer.FindAsync(id);
            if (lecturerModel != null)
            {
                _context.Lecturer.Remove(lecturerModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LecturerModelExists(int id)
        {
          return (_context.Lecturer?.Any(e => e.Lecturer_ID == id)).GetValueOrDefault();
        }
    }
}
