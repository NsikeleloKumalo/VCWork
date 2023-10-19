using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheRideYouRentFinalTest.Models;

namespace TheRideYouRentFinalTest.Controllers
{
    public class ReturnCarController : Controller
    {
        private TheRideYouRentDBContext db = new TheRideYouRentDBContext();

        // GET: ReturnCar
        public ActionResult Index()
        {
            var returnCars = db.ReturnCars.Include(r => r.Inspector).Include(r => r.Rental);
            return View(returnCars.ToList());
        }

        public JsonResult SaveData(string Return_id, string Inspector_no, string Rental_no, string ReturnDate, int Fine)
        {
            // Check if the Return_id already exists in the database
            var existingReturnCar = db.ReturnCars.FirstOrDefault(rc => rc.Return_id == Return_id);

            if (existingReturnCar != null)
            {
                // Update the existing ReturnCar record
                existingReturnCar.Inspector_no = Inspector_no;
                existingReturnCar.Rental_no = Rental_no;
                existingReturnCar.ReturnDate = DateTime.Parse(ReturnDate);
                existingReturnCar.Fine = Fine;
            }
            else
            {
                // Create a new ReturnCar record
                var newReturnCar = new ReturnCar
                {
                    Return_id = Return_id,
                    Inspector_no = Inspector_no,
                    Rental_no = Rental_no,
                    ReturnDate = DateTime.Parse(ReturnDate),
                    Fine = Fine
                };

                db.ReturnCars.Add(newReturnCar);
            }

            // Save the changes to the database
            db.SaveChanges();

            // Return a JSON response indicating success
            return Json(new { success = true });
        }


        [HttpPost]
        public JsonResult Getid(string Return_id)
        {
            var returnCar = db.ReturnCars.FirstOrDefault(rc => rc.Return_id == Return_id);

            if (returnCar != null)
            {
                var elapsedDays = (DateTime.Now - returnCar.ReturnDate).TotalDays;

                var data = new
                {
                    Inspector_no = returnCar.Inspector_no,
                    Rental_no = returnCar.Rental_no,
                    ReturnDate = returnCar.ReturnDate.ToString("yyyy-MM-dd"),
                    Fine = returnCar.Fine,
                    ElapsedDays = elapsedDays
                };

                return Json(new[] { data }, JsonRequestBehavior.AllowGet);
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        // GET: ReturnCar/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReturnCar returnCar = db.ReturnCars.Find(id);
            if (returnCar == null)
            {
                return HttpNotFound();
            }
            return View(returnCar);
        }

        // GET: ReturnCar/Create
        public ActionResult Create()
        {
            ViewBag.Inspector_no = new SelectList(db.Inspectors, "Inspector_no", "InspectorName");
            ViewBag.Rental_no = new SelectList(db.Rentals, "Rental_no", "CarNo");
            return View();
        }

        // POST: ReturnCar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Return_id,Rental_no,Inspector_no,ReturnDate,ElapsedDate,Fine")] ReturnCar returnCar)
        {
            if (ModelState.IsValid)
            {
                db.ReturnCars.Add(returnCar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Inspector_no = new SelectList(db.Inspectors, "Inspector_no", "InspectorName", returnCar.Inspector_no);
            ViewBag.Rental_no = new SelectList(db.Rentals, "Rental_no", "CarNo", returnCar.Rental_no);
            return View(returnCar);
        }

        // GET: ReturnCar/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReturnCar returnCar = db.ReturnCars.Find(id);
            if (returnCar == null)
            {
                return HttpNotFound();
            }
            ViewBag.Inspector_no = new SelectList(db.Inspectors, "Inspector_no", "InspectorName", returnCar.Inspector_no);
            ViewBag.Rental_no = new SelectList(db.Rentals, "Rental_no", "CarNo", returnCar.Rental_no);
            return View(returnCar);
        }

        // POST: ReturnCar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Return_id,Rental_no,Inspector_no,ReturnDate,ElapsedDate,Fine")] ReturnCar returnCar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(returnCar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Inspector_no = new SelectList(db.Inspectors, "Inspector_no", "InspectorName", returnCar.Inspector_no);
            ViewBag.Rental_no = new SelectList(db.Rentals, "Rental_no", "CarNo", returnCar.Rental_no);
            return View(returnCar);
        }

        // GET: ReturnCar/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReturnCar returnCar = db.ReturnCars.Find(id);
            if (returnCar == null)
            {
                return HttpNotFound();
            }
            return View(returnCar);
        }

        // POST: ReturnCar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ReturnCar returnCar = db.ReturnCars.Find(id);
            db.ReturnCars.Remove(returnCar);
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
