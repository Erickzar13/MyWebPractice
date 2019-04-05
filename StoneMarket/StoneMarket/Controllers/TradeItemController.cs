using StoneMarket.Infrastructure;
using StoneMarket.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

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
    }
}