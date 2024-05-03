using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopFront.Models
{
    public class Product
    {
        public char SKU { get; set; }
        public decimal Price { get; set; }  


        public Product(char sku, decimal price)
        {
            SKU = sku;
            Price = price;
        }
    }
}
