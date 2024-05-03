using ShopFront.Models;
using ShopFront.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopFront.Repository.Interfaces
{
    public interface IProductRepository: IRepository<Product, ProductQuery>
    {
    }
}
