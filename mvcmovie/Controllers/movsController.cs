using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvcmovie.Models;

namespace mvcmovie.Controllers
{
    public class movsController : Controller
    {
        private MovieDBContext db = new MovieDBContext();

        // GET: movs
        public ActionResult Index()
        {
            return View(db.Movies.ToList());
        }

        // GET: movs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mov mov = db.Movies.Find(id);
            if (mov == null)
            {
                return HttpNotFound();
            }
            return View(mov);
        }

        // GET: movs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: movs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ReleaseDate,Genre,Price")] mov mov)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(mov);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mov);
        }

        // GET: movs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mov mov = db.Movies.Find(id);
            if (mov == null)
            {
                return HttpNotFound();
            }
            return View(mov);
        }

        // POST: movs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ReleaseDate,Genre,Price")] mov mov)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mov).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mov);
        }

        // GET: movs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mov mov = db.Movies.Find(id);
            if (mov == null)
            {
                return HttpNotFound();
            }
            return View(mov);
        }

        // POST: movs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mov mov = db.Movies.Find(id);
            db.Movies.Remove(mov);
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
