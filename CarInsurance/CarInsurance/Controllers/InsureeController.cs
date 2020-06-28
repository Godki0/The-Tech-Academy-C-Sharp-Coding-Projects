using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarInsurance.Models;

namespace CarInsurance.Controllers
{
    public class InsureeController : Controller
    {
        private InsuranceEntities db = new InsuranceEntities();

        // GET: Insuree
        public ActionResult Index()
        {
            return View(db.Insurees.ToList());
        }

        // GET: Insuree/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // GET: Insuree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insuree/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,Full,Liability,Quote")] Insuree insuree)
        {
            
            using (InsuranceEntities db = new InsuranceEntities())
            {
                
                insuree.Quote = 50;
                
                DateTime inputDate = insuree.DateOfBirth;
                int inputDate2 = int.Parse(inputDate.ToString("yyyy"));
                int currentAge = 2020 - inputDate2;
                if (currentAge <= 18)
                {
                    insuree.Quote += 100;
                }
                else if (18 <= currentAge && currentAge <= 25)
                {
                    insuree.Quote += 50;
                }
                else
                {
                    insuree.Quote += 25;
                }

                
                int inputYear = insuree.CarYear;
                if (inputYear <= 2000)
                {
                    insuree.Quote += 25;
                }
                else if (inputYear >= 2015)
                {
                    insuree.Quote += 25;
                }
                else
                {
                    insuree.Quote += 0;
                }

                
                string inputMake = insuree.CarMake.ToLower();
                if (inputMake == "porsche")
                {
                    insuree.Quote += 25;
                }
                else
                {
                    insuree.Quote += 0;
                }

                string inputModel = insuree.CarModel.ToLower();
                if (inputModel == "911 carrera")
                {
                    insuree.Quote += 25;
                }
                else
                {
                    insuree.Quote += 0;
                }

                //int inputSpeed = insuree.SpeedingTickets;
                //for (inputSpeed = 0; inputSpeed < 30; inputSpeed++)
                //{
                //    insuree.Quote += 10;
                //    inputSpeed++;
                //}
                //if (inputSpeed == 0)
                //{
                //    insuree.Quote += 0;
                //}
                //else if (inputSpeed > 0)
                //{
                //    insuree.Quote += 10;
                //}
                //else
                //{
                //    insuree.Quote += 0;
                //}
                
                bool inputDui = insuree.DUI;
                if(inputDui == true)
                {
                    decimal x = insuree.Quote * .25m;
                    insuree.Quote += x;
                }
                else if (inputDui != true)
                {
                    insuree.Quote += 0;
                }
                else
                {
                    insuree.Quote += 0;
                }

            }


            if (ModelState.IsValid)
            {
                db.Insurees.Add(insuree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(insuree);
        }

        // GET: Insuree/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,Full,Liability,Quote")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insuree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insuree);
        }

        // GET: Insuree/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insuree insuree = db.Insurees.Find(id);
            db.Insurees.Remove(insuree);
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
