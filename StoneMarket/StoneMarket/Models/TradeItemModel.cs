using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoneMarket.Models
{
    public class TradeItemModel
    {
        string Type { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Price { get; set; }
    }
}