using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hotel.Models;

namespace Hotel.Controllers
{
    [Authorize]
    public class ApartmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Apartments
        public async Task<ActionResult> Index()
        {
            var apartments = db.Apartments.Include(a => a.Type);
            return View(await apartments.ToListAsync());
        }

        // GET: Apartments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apartment apartment = await db.Apartments.FindAsync(id);
            if (apartment == null)
            {
                return HttpNotFound();
            }
            return View(apartment);
        }

        // GET: Apartments/Create
        public ActionResult Create()
        {
            ViewBag.ApTypeId = new SelectList(db.ApTypes, "TypeId", "Name");
            return View();
        }

        // POST: Apartments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ApartmentId,Name,ApTypeId")] Apartment apartment)
        {
            if (ModelState.IsValid)
            {
                db.Apartments.Add(apartment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ApTypeId = new SelectList(db.ApTypes, "TypeId", "Name", apartment.ApTypeId);
            return View(apartment);
        }

        // GET: Apartments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apartment apartment = await db.Apartments.FindAsync(id);
            if (apartment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApTypeId = new SelectList(db.ApTypes, "TypeId", "Name", apartment.ApTypeId);
            return View(apartment);
        }

        // POST: Apartments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ApartmentId,Name,ApTypeId")] Apartment apartment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apartment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ApTypeId = new SelectList(db.ApTypes, "TypeId", "Name", apartment.ApTypeId);
            return View(apartment);
        }

        // GET: Apartments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apartment apartment = await db.Apartments.FindAsync(id);
            if (apartment == null)
            {
                return HttpNotFound();
            }
            apartment.Type = await db.ApTypes.FindAsync(apartment.ApTypeId);
            return View(apartment);
        }

        // POST: Apartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Apartment apartment = await db.Apartments.FindAsync(id);
            db.Apartments.Remove(apartment);
            await db.SaveChangesAsync();
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
