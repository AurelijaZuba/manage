using manage.Context;
using manage.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;



namespace manage.Controllers
{
    public class EventsController : Controller
    {
        //connect the database 
        private EventContext db = new EventContext();



        // GET: Events
        public ActionResult Index()
        {
            //List all the venues added to the database and store it
            var venueList = new List<string>();
            var venueQuery = from a in db.Events
                             orderby a.Venue
                             select a.Venue;

            venueList.AddRange(venueQuery.Distinct());
            ViewBag.Venue = new SelectList(venueList);

            var venue = from e in db.Events
                        select e;

            

            return View(venue);
        }

        [HttpPost]
        public ActionResult Index(string Venue, string searchString)
        {

            var venueList = new List<string>();
            var venueQuery = from a in db.Events
                             orderby a.Venue
                             select a.Venue;

            venueList.AddRange(venueQuery.Distinct());
            ViewBag.Venue = new SelectList(venueList);

            var events = from e in db.Events
                         select e;
            //select by venue
            if (!String.IsNullOrEmpty(Venue))
            {
                events = events.Where(x => x.Venue == Venue);
            }
            //select by name 
            if (!String.IsNullOrEmpty(searchString))
            {
                events = events.Where(s => s.EventName.Contains(searchString));
            }


            return View(events);
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Events events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventID,EventName,Venue,Address,Date,Time")] Events events)
        {
            DateTime dt = new DateTime(2008, 3, 9, 16, 5, 7, 123);
            String.Format("{0:dd/MM/yy}", dt);

            if (ModelState.IsValid)
            {
                db.Events.Add(events);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(events);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Events events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventID, EventName,Venue,Address,Date,Time")] Events events)
        {
            if (ModelState.IsValid)
            {
                db.Entry(events).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(events);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Events events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]

        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Events events = db.Events.Find(id);
            db.Events.Remove(events);
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
