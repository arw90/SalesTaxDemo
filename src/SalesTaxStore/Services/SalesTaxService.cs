// <copyright file="SalesTaxService.cs" company="None">
// None
// </copyright>

namespace SalesTaxStore.Services
{
    using System.Collections.Generic;
    using SalesTaxStore.Helpers;
    using SalesTaxStore.Models;

    /// <summary>
    /// The sales tax services
    /// </summary>
    public class SalesTaxService : ITaxService<SalesTaxService>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesTaxService"/> class
        /// </summary>
        public SalesTaxService()
        {
            this.TaxRate = .10M;
        }

        /// <summary>
        /// Gets or sets the tax rate
        /// </summary>
        public decimal TaxRate { get; set; }

        /// <summary>
        /// Calculates tax for an item
        /// </summary>
        /// <param name="product">The product</param>
        /// <returns>A product</returns>
        public Product CalculateTaxForItem(Product product)
        {
            return this.CalculateTax(product);
        }

        /// <summary>
        /// Calculates the tax for all items
        /// </summary>
        /// <param name="products">The products</param>
        /// <returns>The calculated tax</returns>
        public List<Product> CalculateTaxForItems(List<Product> products)
        {
            foreach (var product in products)
            {
                this.CalculateTax(product);
            }

            return products;
        }

        /// <summary>
        /// Calculate the sales tax
        /// </summary>
        /// <param name="product">The product</param>
        /// <returns>A taxed product</returns>
        private Product CalculateTax(Product product)
        {
            /* TODO: Figure out a better way to categorize items...they are all coming from the user input right now so there's no
            obvious way to map product names to categories of items without adding more UI fields for category */
            if (product.Name.Contains("Perfume") || product.Name.Contains("CD"))
            {
                product.SalesTax = TaxHelper.RoundUpToNearestFiveCents(product.BasePrice * this.TaxRate);
            } 

            return product;
        }
    }
}
