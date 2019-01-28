// <copyright file="ProductService.cs" company="None">
// None
// </copyright>

namespace SalesTaxStore.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using SalesTaxStore.Models;
    using SalesTaxStore.Repositories;

    /// <summary>
    /// The product service
    /// </summary>
    public class ProductService : IProductService
    {
        /// <summary>
        /// The product repository
        /// </summary>
        private IProductRepository productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class
        /// </summary>
        /// <param name="productRepo">The product repository</param>
        public ProductService(IProductRepository productRepo)
        {
            this.productRepository = productRepo;
        }

        /// <summary>
        /// Gets the product names
        /// </summary>
        /// <returns>A list of names</returns>
        public List<string> GetProductNames()
        {
            return this.productRepository.GetAllProducts().Select(x => x.Name).ToList();
        }

        /// <summary>
        /// Gets all the products
        /// </summary>
        /// <returns>A list of products</returns>
        public List<Product> GetAllProducts()
        {
            return this.productRepository.GetAllProducts();
        }

        /// <summary>
        /// Gets the product by id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A product</returns>
        public Product GetProductById(int id)
        {
            return this.productRepository.GetProductById(id);
        }

        /// <summary>
        /// Gets the products by Ids
        /// </summary>
        /// <param name="ids">The ids</param>
        /// <returns>A list of products</returns>
        public List<Product> GetProductsByIds(List<int> ids)
        {
            return this.productRepository.GetProductsByIds(ids);
        }
    }
}
