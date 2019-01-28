// <copyright file="Product.cs" company="None">
// None
// </copyright>

namespace SalesTaxStore.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The product class
    /// </summary>
    public class Product
    {
        // Some basic validation just to prove it's here

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Quantity
        /// </summary>
        [Range(1, 10)]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Gets or sets the BasePrice
        /// </summary>
        [Range(1, 100)]
        public decimal BasePrice { get; set; }

        /// <summary>
        /// Gets or sets the SalesTax
        /// </summary>
        public decimal SalesTax { get; set; }

        /// <summary>
        /// Gets or sets the ImportTax
        /// </summary>
        public decimal ImportTax { get; set; }

        /// <summary>
        /// Gets or sets the FinalPrice
        /// </summary>
        public decimal FinalPrice { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the item is imported
        /// </summary>
        public bool IsImported { get; set; }
    }
}
