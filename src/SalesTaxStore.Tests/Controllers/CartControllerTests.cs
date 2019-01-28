// <copyright file="CartControllerTests.cs" company="None">
// None
// </copyright>

namespace Tests
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using NUnit.Framework;
    using SalesTaxStore.Controllers;
    using SalesTaxStore.Models;
    using SalesTaxStore.Services;

    /// <summary>
    /// The cart controller tests
    /// </summary>
    public class CartControllerTests
    {
        /// <summary>
        /// The product service mock
        /// </summary>
        private Mock<IShoppingCartService> productService;

        /// <summary>
        /// The test subject
        /// </summary>
        private CartController sut;

        /// <summary>
        /// Set up the tests
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.productService = new Mock<IShoppingCartService>();

            var mockReceipt = new Receipt()
            {
                PurchasedProducts = new List<ReceiptLineItem>(),
                TotalPrice = 100,
                TotalSalesTax = 5
            };

            this.productService.Setup(x => x.GenerateCheckoutReceipt()).Returns(mockReceipt);

            this.sut = new CartController(this.productService.Object);
        }

        /// <summary>
        /// See method name
        /// </summary>
        [Test]
        public void Cart_IndexPage_ShouldReturn_ViewResult()
        {
            // no arrange

            // act
            var result = this.sut.Index() as ViewResult;

            // assert that we get a view result with a receipt
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Receipt>(result.Model);
        }
    }
}