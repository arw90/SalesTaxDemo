// <copyright file="TaxHelper.cs" company="None">
// None
// </copyright>

namespace SalesTaxStore.Helpers
{
    using System;
    
    /// <summary>
    /// The tax helpers
    /// </summary>
    public static class TaxHelper
    {
        /// <summary>
        /// Rounds up to nearest 5 cents
        /// </summary>
        /// <param name="input">The input value</param>
        /// <returns>A rounded number</returns>
        public static decimal RoundUpToNearestFiveCents(decimal input)
        {
            var ceiling = Math.Ceiling(input * 20);

            return ceiling == 0 ? 0 : ceiling / 20;
        }
    }
}
