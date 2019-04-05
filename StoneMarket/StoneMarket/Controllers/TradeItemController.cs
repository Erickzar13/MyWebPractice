using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoneMarket.Infrastructure;
using StoneMarket.Models;

namespace StoneMarket.Controllers
{
    public class TradeItemController : Controller
    {
        private StoneMarketDbContext db = new StoneMarketDbContext();

        // GET: TradeItem
        public async Task<ActionResult> Index()
        {
            return View(await db.TradeItems.ToListAsync());
        }

        // GET: TradeItem/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TradeItemModel tradeItemModel = await db.TradeItems.FindAsync(id);
            if (tradeItemModel == null)
            {
                return HttpNotFound();
            }
            return View(tradeItemModel);
        }

        // GET: TradeItem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TradeItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TradeItemId,Type,Name,Description,Price")] TradeItemModel tradeItemModel)
        {
            if (ModelState.IsValid)
            {
                db.TradeItems.Add(tradeItemModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tradeItemModel);
        }

        // GET: TradeItem/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TradeItemModel tradeItemModel = await db.TradeItems.FindAsync(id);
            if (tradeItemModel == null)
            {
                return HttpNotFound();
            }
            return View(tradeItemModel);
        }

        // POST: TradeItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TradeItemId,Type,Name,Description,Price")] TradeItemModel tradeItemModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tradeItemModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tradeItemModel);
        }

        // GET: TradeItem/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TradeItemModel tradeItemModel = await db.TradeItems.FindAsync(id);
            if (tradeItemModel == null)
            {
                return HttpNotFound();
            }
            return View(tradeItemModel);
        }

        // POST: TradeItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TradeItemModel tradeItemModel = await db.TradeItems.FindAsync(id);
            db.TradeItems.Remove(tradeItemModel);
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
