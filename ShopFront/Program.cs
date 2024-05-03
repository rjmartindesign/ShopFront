using ShopFront.Models;
using ShopFront.Repository.Interfaces;
using ShopFront.Repository;
using ShopFront.Services;
using System;

class Program
{
    static void Main(string[] args)
    {// Output current directory for debugging
        Console.WriteLine($"Current Directory: {Directory.GetCurrentDirectory()}");

        //Get Repos
        string basePath = AppDomain.CurrentDomain.BaseDirectory; 
        string projectRootDirectory = Directory.GetParent(basePath).Parent.Parent.Parent.FullName;
        string productJsonFilePath = Path.Combine(projectRootDirectory, "AppData/products.json");
        string offerJsonFilePath = Path.Combine(projectRootDirectory, "AppData/offers.json");

        IProductRepository productRepository = new ProductRepository(productJsonFilePath);
        IOfferRepository offerRepository = new OfferRepository(offerJsonFilePath);

        //Create Service
        CheckoutService checkoutService = new CheckoutService(productRepository, offerRepository);

        //Get Products from User
        List<char> products = new List<char>();
        Console.WriteLine("Add products");

        //Alow the user to add products.
        while (true)
        {
            Console.Write("Enter SKU (single character): ");
            char inputChar;
            if (char.TryParse(Console.ReadLine().ToUpper(), out inputChar))
            {
                if (char.IsDigit(inputChar))
                {
                    Console.WriteLine("Invalid input. Please enter a character (SKU).");
                    continue;
                }

                products.Add(inputChar);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a single character (SKU).");
                continue; 
            }

            Console.Write("Add another product? (Y/N): ");
            if (Console.ReadLine().ToUpper() != "Y")
                break;
        }

        //Calculate Total Price
        decimal total = checkoutService.CalculateTotalPrice(products).Result;
        Console.WriteLine($"Total Price: {total:C}");
    }
}