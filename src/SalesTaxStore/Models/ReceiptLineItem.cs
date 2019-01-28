// <copyright file="ReceiptLineItem.cs" company="None">
// None
// </copyright>

namespace SalesTaxStore.Models
{
    /// <summary>
    /// A receipt line item for simplicity
    /// </summary>
    public class ReceiptLineItem
    {
        /// <summary>
        /// Gets or sets the product name
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the price
        /// </summary>
        public decimal ProductPrice { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the item is imported
        /// </summary>
        public bool IsImported { get; set; }

        /// <summary>
        /// Gets or sets the quantity
        /// </summary>
        public string QuantityLabel { get; set; }
    }
}
