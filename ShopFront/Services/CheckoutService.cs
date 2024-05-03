using ShopFront.Models;
using ShopFront.Models.Query;
using ShopFront.Repository.Interfaces;
using ShopFront.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopFront.Services
{
    public class CheckoutService : ICheckOutService
    {
        private IProductRepository _productRepository;
        private IOfferRepository _offerRepository;

        public CheckoutService(IProductRepository productRepository, IOfferRepository offerRepository)
        {
            _productRepository = productRepository;
            _offerRepository = offerRepository;
        }
        public async Task<decimal> CalculateTotalPrice(List<char> skus)
        {
            decimal totalPrice = 0;
            IEnumerable<Product> products = await _productRepository.GetAll();
            IEnumerable<Offer> offers = await _offerRepository.GetAll();

            // Get Quantites of orders
            Dictionary<char, int> skuQuantities = new Dictionary<char, int>();
            foreach (char sku in skus)
            {
                if (skuQuantities.ContainsKey(sku))
                {
                    skuQuantities[sku]++;
                }
                else
                {
                    skuQuantities[sku] = 1;
                }
            }

            // Apply offers
            foreach (var kvp in skuQuantities)
            {
                char sku = kvp.Key;
                int quantity = kvp.Value;

                // Find the product corresponding to the SKU
                Product product = products.FirstOrDefault(p => p.SKU == sku);
                if (product == null)
                {
                    throw new InvalidOperationException($"Product with SKU '{sku}' not found.");
                }

                // get a list of how many times the offer is met
                IEnumerable<Offer> applicableOffers = offers.Where(o => o.SKU == sku && o.Quantity <= quantity);

                if (applicableOffers.Any())
                {
                    decimal skuTotalPrice = 0;
                    foreach (var offer in applicableOffers)
                    {
                        // how many tiems is offer applied
                        int offerApplications = quantity / offer.Quantity;
                        // any left after offer applied
                        int remainingQuantity = quantity % offer.Quantity; 

                        decimal offerPrice = offerApplications * offer.SpecialPrice + remainingQuantity * product.Price;

                        skuTotalPrice = Math.Min(offerPrice, quantity * product.Price);
                    }

                    totalPrice += skuTotalPrice;
                }
                else
                {
                    // No offers applicable, apply full price
                    totalPrice += quantity * product.Price;
                }
            }

            return Math.Round(totalPrice, 2);

        }
    }
}
