﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CLDVTwo.Data;
using CLDVTwo.Models;

namespace CLDVTwo.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DbContextData _context;

        public EmployeeController(DbContextData context)
        {
            _context = context;
        }

        // GET: Employee
        //public async Task<IActionResult> Index()
        //{
        //      return _context.Employees != null ? 
        //                  View(await _context.Employees.ToListAsync()) :
        //                  Problem("Entity set 'DbContextData.Employees'  is null.");
        //}

       public async Task<IActionResult> Index(string searchString)
        {
           if (_context.Employees == null)
           {
              return Problem("Entity set 'DbContextData.Employees'   is null.");
          }

                var Employees = from m in _context.Employees
                       select m;

           if (!String.IsNullOrEmpty(searchString))
           {
               Employees = Employees.Where(s => s.EmployeeName!.Contains(searchString));
          }

         return View(await Employees.ToListAsync());
        }

        //public async Task<IActionResult> Index(string id)
        //{
        //    if (_context.Employees == null)
        //    {
        //        return Problem("Entity set 'DbContextData.Employees'  is null.");
        //    }

        //    var Employees = from m in _context.Employees
        //                 select m;

        //    if (!String.IsNullOrEmpty(id))
        //    {
        //        Employees = Employees.Where(s => s.EmployeeName!.Contains(id));
        //    }

        //    return View(await Employees.ToListAsync());
        //}

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employeeModel = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeModel == null)
            {
                return NotFound();
            }

            return View(employeeModel);
        }



        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeName,EmployeeSurname,EmployeeEmail,EmployeePhone,EmployeeCity,EmployeeRegion,EmployeePostalCode,EmployeeCountry,EmployeeState,EmployeeAge,EmployeeCount,EmployeeJobDesc,EmployeeManagerId")] EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeModel);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employeeModel = await _context.Employees.FindAsync(id);
            if (employeeModel == null)
            {
                return NotFound();
            }
            return View(employeeModel);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeName,EmployeeSurname,EmployeeEmail,EmployeePhone,EmployeeCity,EmployeeRegion,EmployeePostalCode,EmployeeCountry,EmployeeState,EmployeeAge,EmployeeCount,EmployeeJobDesc,EmployeeManagerId")] EmployeeModel employeeModel)
        {
            if (id != employeeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeModelExists(employeeModel.Id))
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
            return View(employeeModel);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employeeModel = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeModel == null)
            {
                return NotFound();
            }

            return View(employeeModel);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Employees == null)
            {
                return Problem("Entity set 'DbContextData.Employees'  is null.");
            }
            var employeeModel = await _context.Employees.FindAsync(id);
            if (employeeModel != null)
            {
                _context.Employees.Remove(employeeModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeModelExists(int id)
        {
          return (_context.Employees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
