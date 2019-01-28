// <copyright file="IProductRepository.cs" company="None">
// None
// </copyright>

namespace SalesTaxStore.Repositories
{
    using System.Collections.Generic;
    using SalesTaxStore.Models;

    /// <summary>
    /// An interface for a product repository
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Gets the product names
        /// </summary>
        /// <returns>A list of names</returns>
        List<string> GetProductNames();

        /// <summary>
        /// Gets all the products
        /// </summary>
        /// <returns>A list of products</returns>
        List<Product> GetAllProducts();

        /// <summary>
        /// Gets the products by ids
        /// </summary>
        /// <param name="ids">A list of ids</param>
        /// <returns>A list of products</returns>
        List<Product> GetProductsByIds(List<int> ids);

        /// <summary>
        /// Gets the product by id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A product</returns>
        Product GetProductById(int id);
    }
}
