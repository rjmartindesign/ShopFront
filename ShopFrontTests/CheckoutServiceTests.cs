using ShopFront.Repository.Interfaces;
using ShopFront.Services;
using ShopFrontTests.Mocks;
using System;

[TestFixture]
public class CheckoutServiceTests
{
    private CheckoutService _checkoutService;
    private decimal _result;

    [SetUp]
    public void Setup()
    {
        // Mock repositories and create CheckoutService instance
        IProductRepository productRepository = new MockProductRepository();
        IOfferRepository offerRepository = new MockOfferRepository();
        _checkoutService = new CheckoutService(productRepository, offerRepository);
    }

    [Test]
    [TestCase(new char[] { }, 0)]
    [TestCase(new char[] { 'A' }, 50.00)]
    [TestCase(new char[] { 'A', 'B' }, 80.00)]
    [TestCase(new char[] { 'C', 'D', 'B', 'A' }, 115.00)]
    [TestCase(new char[] { 'A', 'A' }, 100.00)]
    [TestCase(new char[] { 'A', 'A', 'A' }, 130.00)]
    [TestCase(new char[] { 'A', 'A', 'A', 'B', 'B' }, 175.00)]
    [TestCase(new char[] { 'A', 'A', 'A', 'A' }, 180.00)]
    [TestCase(new char[] { 'A', 'A', 'A', 'A', 'A', 'A', 'A' }, 310.00)]
    public void Test_CalculateTotalPrice(char[] skus, decimal result)
    {
        Assert.That(_checkoutService.CalculateTotalPrice(skus.ToList()).Result, Is.EqualTo(result));
    }


}