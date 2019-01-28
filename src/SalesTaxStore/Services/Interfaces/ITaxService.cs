// <copyright file="ITaxService.cs" company="None">
// None
// </copyright>

namespace SalesTaxStore.Services
{
    using System.Collections.Generic;
    using SalesTaxStore.Models;

    /// <summary>
    /// A a generic tax service with type parameter to allow for multiple dependency registrations
    /// </summary>
    /// <typeparam name="T">The type of tax service</typeparam>
    public interface ITaxService<T>
    {
        /// <summary>
        /// Gets or sets the tax rate
        /// </summary>
        decimal TaxRate { get; set; }

        /// <summary>
        /// Calculate the tax for the item
        /// </summary>
        /// <param name="product">The product</param>
        /// <returns>Returns a taxed product</returns>
        Product CalculateTaxForItem(Product product);

        /// <summary>
        /// Calculates the tax for multiple products
        /// </summary>
        /// <param name="products">The products</param>
        /// <returns>The calculated tax</returns>
        List<Product> CalculateTaxForItems(List<Product> products);
    }
}
