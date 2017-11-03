using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClassworkPractic;

namespace ClassworkPractic.Controllers
{
    public class SessionsController : Controller
    {
        private Cinema db = new Cinema();

        // GET: Sessions
        public ActionResult Index()
        {
            var sessions = db.Sessions.Include(s => s.FilmLibrary).Include(s => s.Halls);
            return View(sessions.ToList());
        }

        // GET: Sessions/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sessions sessions = db.Sessions.Find(id);
            if (sessions == null)
            {
                return HttpNotFound();
            }
            return View(sessions);
        }

        // GET: Sessions/Create
        public ActionResult Create()
        {
            ViewBag.FilmID = new SelectList(db.FilmLibrary, "FilmID", "Title");
            ViewBag.HallID = new SelectList(db.Halls, "HallId", "HallName");
            return View();
        }

        // POST: Sessions/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SessionId,FilmID,Date,HallID,Price")] Sessions sessions)
        {
            if (ModelState.IsValid)
            {
                db.Sessions.Add(sessions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FilmID = new SelectList(db.FilmLibrary, "FilmID", "Title", sessions.FilmID);
            ViewBag.HallID = new SelectList(db.Halls, "HallId", "HallName", sessions.HallID);
            return View(sessions);
        }

        // GET: Sessions/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sessions sessions = db.Sessions.Find(id);
            if (sessions == null)
            {
                return HttpNotFound();
            }
            ViewBag.FilmID = new SelectList(db.FilmLibrary, "FilmID", "Title", sessions.FilmID);
            ViewBag.HallID = new SelectList(db.Halls, "HallId", "HallName", sessions.HallID);
            return View(sessions);
        }

        // POST: Sessions/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SessionId,FilmID,Date,HallID,Price")] Sessions sessions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sessions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FilmID = new SelectList(db.FilmLibrary, "FilmID", "Title", sessions.FilmID);
            ViewBag.HallID = new SelectList(db.Halls, "HallId", "HallName", sessions.HallID);
            return View(sessions);
        }

        // GET: Sessions/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sessions sessions = db.Sessions.Find(id);
            if (sessions == null)
            {
                return HttpNotFound();
            }
            return View(sessions);
        }

        // POST: Sessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Sessions sessions = db.Sessions.Find(id);
            db.Sessions.Remove(sessions);
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
