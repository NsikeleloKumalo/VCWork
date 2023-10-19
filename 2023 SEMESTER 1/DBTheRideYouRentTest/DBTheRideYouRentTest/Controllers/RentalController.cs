using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DBTheRideYouRentTest.Models;

namespace DBTheRideYouRentTest.Controllers
{
    public class RentalController : Controller
    {
        private RideYouRentDBContext db = new RideYouRentDBContext();

        // GET: Rental
        public ActionResult Index()
        {
            var rentals = db.Rentals.Include(r => r.Car).Include(r => r.Driver).Include(r => r.Inspector);
            return View(rentals.ToList());
        }

        // GET: Rental/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rentals.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            return View(rental);
        }

        // GET: Rental/Create
        public ActionResult Create()
        {
            ViewBag.CarNo = new SelectList(db.Cars, "CarNo", "Car_Make");
            ViewBag.Driver_ID = new SelectList(db.Drivers, "Driver_ID", "DriverName");
            ViewBag.Inspector_no = new SelectList(db.Inspectors, "Inspector_no", "InspectorName");
            return View();
        }

        // POST: Rental/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Rental_no,RentalFee,StartDate,EndDate,CarNo,Inspector_no,Driver_ID")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                db.Rentals.Add(rental);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarNo = new SelectList(db.Cars, "CarNo", "Car_Make", rental.CarNo);
            ViewBag.Driver_ID = new SelectList(db.Drivers, "Driver_ID", "DriverName", rental.Driver_ID);
            ViewBag.Inspector_no = new SelectList(db.Inspectors, "Inspector_no", "InspectorName", rental.Inspector_no);
            return View(rental);
        }

        // GET: Rental/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rentals.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarNo = new SelectList(db.Cars, "CarNo", "Car_Make", rental.CarNo);
            ViewBag.Driver_ID = new SelectList(db.Drivers, "Driver_ID", "DriverName", rental.Driver_ID);
            ViewBag.Inspector_no = new SelectList(db.Inspectors, "Inspector_no", "InspectorName", rental.Inspector_no);
            return View(rental);
        }

        // POST: Rental/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Rental_no,RentalFee,StartDate,EndDate,CarNo,Inspector_no,Driver_ID")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rental).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarNo = new SelectList(db.Cars, "CarNo", "Car_Make", rental.CarNo);
            ViewBag.Driver_ID = new SelectList(db.Drivers, "Driver_ID", "DriverName", rental.Driver_ID);
            ViewBag.Inspector_no = new SelectList(db.Inspectors, "Inspector_no", "InspectorName", rental.Inspector_no);
            return View(rental);
        }

        // GET: Rental/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rentals.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            return View(rental);
        }

        // POST: Rental/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Rental rental = db.Rentals.Find(id);
            db.Rentals.Remove(rental);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
