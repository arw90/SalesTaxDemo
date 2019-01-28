// <copyright file="Receipt.cs" company="None">
// None
// </copyright>

namespace SalesTaxStore.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// The receipt
    /// </summary>
    public class Receipt
    {
        /// <summary>
        /// Gets or sets the products in the cart
        /// </summary>
        public List<ReceiptLineItem> PurchasedProducts { get; set; }

        /// <summary>
        /// Gets or sets The total sales tax
        /// </summary>
        public decimal TotalSalesTax { get; set; }

        /// <summary>
        /// Gets or sets The total price
        /// </summary>
        public decimal TotalPrice { get; set; }
    }
}
