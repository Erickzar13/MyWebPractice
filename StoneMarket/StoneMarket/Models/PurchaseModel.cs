using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoneMarket.Models
{
    public class PurchaseModel
    {
        string CustomerId { get; set; }
        string Address { get; set; }
        public int TradeItemId { get; set; }
    }
}