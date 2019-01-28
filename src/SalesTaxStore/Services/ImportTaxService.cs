// <copyright file="ImportTaxService.cs" company="None">
// None
// </copyright>

namespace SalesTaxStore.Services
{
    using System.Collections.Generic;
    using SalesTaxStore.Helpers;
    using SalesTaxStore.Models;

    /// <summary>
    /// The import tax service
    /// </summary>
    public class ImportTaxService : ITaxService<ImportTaxService>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImportTaxService"/> class
        /// </summary>
        public ImportTaxService()
        {
            this.TaxRate = .05M;
        }

        /// <summary>
        /// Gets or sets the tax rate
        /// </summary>
        public decimal TaxRate { get; set; }

        /// <summary>
        /// Calculates the tax
        /// </summary>
        /// <param name="product">The item</param>
        /// <returns>Calculated Item</returns>
        public Product CalculateTaxForItem(Product product)
        {
            return this.CalculateImportTax(product);
        }

        /// <summary>
        /// Calculates tax for multiple
        /// </summary>
        /// <param name="products">The products</param>
        /// <returns>A list of products</returns>
        public List<Product> CalculateTaxForItems(List<Product> products)
        {
            foreach (var product in products)
            {
                this.CalculateImportTax(product);
            }

            return products;
        }

        /// <summary>
        /// Calculates the import tax
        /// </summary>
        /// <param name="product">The product</param>
        /// <returns>A product</returns>
        private Product CalculateImportTax(Product product)
        {
            if (product.IsImported)
            {
                product.ImportTax = TaxHelper.RoundUpToNearestFiveCents(product.BasePrice * this.TaxRate);
            }

            return product;
        }
    }
}
