using ShopFront.Models;
using ShopFront.Models.Query;
using ShopFront.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopFrontTests.Mocks
{
    public class MockProductRepository : IProductRepository
    {
        private IEnumerable<Product> _offers = new List<Product>
        {
            new Product('A',50),
            new Product('B', 30),
            new Product('C', 20),
            new Product('D', 15)
        };
        public Task<IEnumerable<Product>> Get(ProductQuery query)
        {
            IEnumerable<Product> filteredOffers = _offers.Where(o => o.SKU == query.SKU);
            return Task.FromResult(filteredOffers);
        }

        public Task<IEnumerable<Product>> GetAll()
        {
            return Task.FromResult(_offers);
        }
    }
}
