using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StoneMarket.Models
{
    [Table("Purchases")]
    public class PurchaseModel
    {
        [Key]
        public string PurchaseId { get; set; }
        public string CustomerId { get; set; }
        public string Address { get; set; }
        public ICollection<TradeItemModel> TradeItems { get; set; }
    }
}