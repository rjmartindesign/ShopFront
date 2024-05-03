using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopFront.Models.Query
{
    public class OfferQuery: IQuery
    {
        public char SKU { get; set; }
        public int quantity { get; set; }
        public decimal specialPrice { get; set; }
    }
}
