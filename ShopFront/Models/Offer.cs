using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopFront.Models
{
    public class Offer
    {
        public char SKU { get; set; }        
        public int Quantity { get; set; }     
        public decimal SpecialPrice { get; set; }  

        public Offer(char sku, int quantity, decimal specialPrice)
        {
            SKU = sku;
            Quantity = quantity;
            SpecialPrice = specialPrice;
        }
    }
}
