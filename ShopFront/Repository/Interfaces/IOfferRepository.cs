using ShopFront.Models.Query;
using ShopFront.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopFront.Repository.Interfaces
{
    public interface IOfferRepository: IRepository<Offer, OfferQuery>
    {
    }
}
