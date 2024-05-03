using ShopFront.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopFront.Repository.Interfaces
{
    public interface IRepository<T, Q> where Q : IQuery
    {
        Task<IEnumerable<T>> Get(Q query);
        Task<IEnumerable<T>> GetAll();
    }
}
