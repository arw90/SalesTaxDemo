// <copyright file="TaxHelperTests.cs" company="None">
// None
// </copyright>

namespace Tests
{
    using NUnit.Framework;
    using SalesTaxStore.Helpers;

    /// <summary>
    /// The tax helper tests
    /// </summary>
    public class TaxHelperTests
    {
        /// <summary>
        /// Set up the tests
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// See test name
        /// </summary>
        [Test]
        public void Should_Round_Up_To_Nearest_5_Cents()
        {
            // Statically check to make sure we're always rounding up to the nearest five cents in various scenarios
            Assert.AreEqual(1.45M, TaxHelper.RoundUpToNearestFiveCents(1.42M));
            Assert.AreEqual(1.45M, TaxHelper.RoundUpToNearestFiveCents(1.44M));
            Assert.AreEqual(2.60M, TaxHelper.RoundUpToNearestFiveCents(2.56M));
            Assert.AreEqual(2.60M, TaxHelper.RoundUpToNearestFiveCents(2.59M));
        }
    }
}