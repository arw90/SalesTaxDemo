// <copyright file="IShoppingCartService.cs" company="None">
// None
// </copyright>

namespace SalesTaxStore.Services
{
    using System.Collections.Generic;
    using SalesTaxStore.Models;

    /// <summary>
    /// The shopping cart service
    /// </summary>
    public interface IShoppingCartService
    {
        /// <summary>
        /// Adds a product to the cart
        /// </summary>
        /// <param name="product">The product</param>
        void AddProductToCart(Product product);

        /// <summary>
        /// Adds multiple products
        /// </summary>
        /// <param name="products">List of products</param>
        void AddProductsToCart(List<Product> products);

        /// <summary>
        /// Generates a receipt
        /// </summary>
        /// <returns>The receipt</returns>
        Receipt GenerateCheckoutReceipt();
    }
}