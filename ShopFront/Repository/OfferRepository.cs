using Newtonsoft.Json;
using ShopFront.Models;
using ShopFront.Models.Query;
using ShopFront.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopFront.Repository
{
    public class OfferRepository : IOfferRepository
    {

        private readonly string _jsonFilePath;

        public OfferRepository(string jsonFilePath)
        {
            _jsonFilePath = jsonFilePath;
        }
        public async Task<IEnumerable<Offer>> Get(OfferQuery query)
        {
            try
            {
                string jsonContent = await File.ReadAllTextAsync(_jsonFilePath);

                if (jsonContent != null)
                {
                    List<Offer> offers = JsonConvert.DeserializeObject<List<Offer>>(jsonContent);

                    return offers.Where(x => x.SKU == query.SKU);
                }
                else
                {
                    throw new InvalidOperationException("No Offers Found!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Offer>> GetAll()
        {
            try
            {
                string jsonContent = await File.ReadAllTextAsync(_jsonFilePath);

                if (jsonContent != null)
                {
                    List<Offer> offers = JsonConvert.DeserializeObject<List<Offer>>(jsonContent);

                    return offers;
                }
                else
                {
                    throw new InvalidOperationException("No Offers Found!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

