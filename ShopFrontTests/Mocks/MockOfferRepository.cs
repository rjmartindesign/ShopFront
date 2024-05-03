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
    public  class MockOfferRepository : IOfferRepository
    {
        private IEnumerable<Offer> _offers = new List<Offer>
        {
            new Offer('A',3, 130),
            new Offer('B', 2, 45)
        };
        public Task<IEnumerable<Offer>> Get(OfferQuery query)
        {
            IEnumerable<Offer> filteredOffers = _offers.Where(o => o.SKU == query.SKU);
            return Task.FromResult(filteredOffers);
        }

        public Task<IEnumerable<Offer>> GetAll()
        {
            return Task.FromResult(_offers);
        }
    }
}
