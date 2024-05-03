using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopFront.Models.Query
{
    public class ProductQuery: IQuery
    {
        public char SKU { get; set; }
        public decimal price { get; set; }
    }
}
