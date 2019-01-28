// <copyright file="SalesTaxServiceTests.cs" company="None">
// None
// </copyright>

namespace Tests
{
    using NUnit.Framework;
    using SalesTaxStore.Models;
    using SalesTaxStore.Services;

    /// <summary>
    /// The sales tax service
    /// </summary>
    public class SalesTaxServiceTests
    {
        /// <summary>
        /// The test subject
        /// </summary>
        private SalesTaxService sut;

        /// <summary>
        /// The set up
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.sut = new SalesTaxService();
        }

        /// <summary>
        /// See test name
        /// </summary>
        [Test]
        public void ShouldApply_SalesTax_To_NonFoodMedicalBook_Items()
        {
            // arrange
            var product = new Product()
            {
                Name = "Perfume",
                BasePrice = 10,
                SalesTax = 0
            };

            // act
            var result = this.sut.CalculateTaxForItem(product);

            // assert
            Assert.AreEqual(result.SalesTax, 1);
        }

        /// <summary>
        /// See test name
        /// </summary>
        [Test]
        public void ShouldNotApply_SalesTax_To_FoodMedicalBook_Items()
        {
            // arrange
            var product = new Product()
            {
                Name = "Book",
                BasePrice = 10,
                SalesTax = 0
            };

            // act
            var result = this.sut.CalculateTaxForItem(product);

            // assert
            Assert.AreEqual(result.SalesTax, 0);
        }
    }
}