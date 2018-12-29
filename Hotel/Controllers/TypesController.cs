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
    public class TypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Types
        public async Task<ActionResult> Index()
        {
            return View(await db.ApTypes.ToListAsync());
        }

        // GET: Types/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApType apType = await db.ApTypes.FindAsync(id);
            if (apType == null)
            {
                return HttpNotFound();
            }
            return View(apType);
        }

        // GET: Types/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Types/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TypeId,Name,Price,Description,NumOfPerson")] ApType apType)
        {
            if (ModelState.IsValid)
            {
                db.ApTypes.Add(apType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(apType);
        }

        // GET: Types/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApType apType = await db.ApTypes.FindAsync(id);
            if (apType == null)
            {
                return HttpNotFound();
            }
            return View(apType);
        }

        // POST: Types/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ApType apType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(apType);
        }

        // GET: Types/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApType apType = await db.ApTypes.FindAsync(id);
            if (apType == null)
            {
                return HttpNotFound();
            }
            return View(apType);
        }

        // POST: Types/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ApType apType = await db.ApTypes.FindAsync(id);
            db.ApTypes.Remove(apType);
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
