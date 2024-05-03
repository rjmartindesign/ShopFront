using ShopFront.Models;
using ShopFront.Models.Query;
using ShopFront.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ShopFront.Repository
{
    public class ProductRepository : IProductRepository

    {
        private readonly string _jsonFilePath;

        public ProductRepository(string jsonFilePath)
        {
            _jsonFilePath = jsonFilePath;
        }
        public async Task<IEnumerable<Product>> Get(ProductQuery query)
        {
            try
            {
                string jsonContent = await File.ReadAllTextAsync(_jsonFilePath);

                if(jsonContent != null)
                {
                    List<Product> products = JsonConvert.DeserializeObject<List<Product>>(jsonContent);

                    return products.Where(x => x.SKU == query.SKU);
                }
                else
                {
                    throw new InvalidOperationException("No Products Found!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            try
            {
                string jsonContent = await File.ReadAllTextAsync(_jsonFilePath);

                List<Product> products = JsonConvert.DeserializeObject<List<Product>>(jsonContent);

                return products;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
