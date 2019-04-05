using StoneMarket.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StoneMarket.Infrastructure
{
    public class StoneMarketDbContext : DbContext
    {
        public DbSet<PurchaseModel> Purchases { get; set; }
        public DbSet<TradeItemModel> TradeItems { get; set; }
    }
}