// <copyright file="ImportTaxServiceTests.cs" company="None">
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
    public class ImportTaxServiceTests
    {
        /// <summary>
        /// The test subject
        /// </summary>
        private ImportTaxService sut;

        /// <summary>
        /// The set up
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.sut = new ImportTaxService();
        }

        /// <summary>
        /// See test name
        /// </summary>
        [Test]
        public void ShouldApply_ImportTax_To_Imported_Items()
        {
            // arrange
            var product = new Product()
            {
                Name = "Box of Chocolates",
                BasePrice = 10,
                IsImported = true
            };

            // act
            var result = this.sut.CalculateTaxForItem(product);

            // assert
            Assert.AreEqual(result.ImportTax, .5);
        }

        /// <summary>
        /// See test name
        /// </summary>
        [Test]
        public void ShouldNotApply_ImportTax_To_Domestic_Items()
        {
            // arrange
            var product = new Product()
            {
                Name = "Book",
                BasePrice = 10,
                IsImported = false
            };

            // act
            var result = this.sut.CalculateTaxForItem(product);

            // assert
            Assert.AreEqual(result.ImportTax, 0);
        }
    }
}