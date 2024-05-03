using ShopFront.Models;
using ShopFront.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopFront.Services.Interfaces
{
    public interface ICheckOutService
    {
        Task<decimal> CalculateTotalPrice(List<char> skus);
    }
}
