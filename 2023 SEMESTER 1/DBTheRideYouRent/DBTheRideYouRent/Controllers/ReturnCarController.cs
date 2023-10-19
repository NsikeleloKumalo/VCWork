using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DBTheRideYouRent.Models;

namespace DBTheRideYouRent.Controllers
{
    public class ReturnCarController : Controller
    {
        private RideYouRentDBContext db = new RideYouRentDBContext();

        // GET: ReturnCar
        public ActionResult Index()
        {
            var returnCars = db.ReturnCars.Include(r => r.Inspector).Include(r => r.Rental);
            return View(returnCars.ToList());
        }

        public JsonResult Getid(string Return_id)
        {
            var returnCar = db.ReturnCars.FirstOrDefault(rc => rc.Return_id == Return_id);

            if (returnCar != null)
            {
                var data = new
                {
                    Inspector_no = returnCar.Inspector_no,
                    Rental_no = returnCar.Rental_no,
                    ReturnDate = returnCar.ReturnDate.ToString("yyyy-MM-dd"),
                    Fine = returnCar.Fine
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
