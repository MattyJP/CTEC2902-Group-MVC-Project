using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReviewSite.Models;

namespace ReviewSite.Controllers
{
    public class GossipsController : Controller
    {
        private GossipContext db = new GossipContext();

        // GET: Gossips
        public ActionResult Index()
        {
            return View(db.Gossips.ToList());
        }

        // GET: Gossips/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gossip gossip = db.Gossips.Find(id);
            if (gossip == null)
            {
                return HttpNotFound();
            }
            return View(gossip);
        }

        // GET: Gossips/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gossips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GossipId,FilmName,Genre,GossipText")] Gossip gossip)
        {
            if (ModelState.IsValid)
            {
                db.Gossips.Add(gossip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gossip);
        }

        // GET: Gossips/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gossip gossip = db.Gossips.Find(id);
            if (gossip == null)
            {
                return HttpNotFound();
            }
            return View(gossip);
        }

        // POST: Gossips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GossipId,FilmName,Genre,GossipText")] Gossip gossip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gossip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gossip);
        }

        // GET: Gossips/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gossip gossip = db.Gossips.Find(id);
            if (gossip == null)
            {
                return HttpNotFound();
            }
            return View(gossip);
        }

        // POST: Gossips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gossip gossip = db.Gossips.Find(id);
            db.Gossips.Remove(gossip);
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
