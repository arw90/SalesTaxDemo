// <copyright file="IProductService.cs" company="None">
// None
// </copyright>

namespace SalesTaxStore.Services
{
    using System.Collections.Generic;
    using SalesTaxStore.Models;

    /// <summary>
    /// The product service contract
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets the product names
        /// </summary>
        /// <returns>A list of strings</returns>
        List<string> GetProductNames();

        /// <summary>
        /// Gets all the products
        /// </summary>
        /// <returns>A list of products</returns>
        List<Product> GetAllProducts();

        /// <summary>
        /// Gets the product by id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A product</returns>
        Product GetProductById(int id);

        /// <summary>
        /// Gets the products
        /// </summary>
        /// <param name="id">The ids</param>
        /// <returns>A list of products</returns>
        List<Product> GetProductsByIds(List<int> id);
    }
}
