// <copyright file="ProductRepository.cs" company="None">
// None
// </copyright>

namespace SalesTaxStore.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using SalesTaxStore.Models;

    /// <summary>
    /// The product repository
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        /// <summary>
        /// The products
        /// </summary>
        private List<Product> products;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class
        /// </summary>
        public ProductRepository()
        {
            // Some sample products to populate the UI options
            this.products = new List<Product>()
            {
                new Product()
                {
                    Name = "Book"
                },
                new Product()
                {
                    Name = "Music CD"
                },
                new Product()
                {
                    Name = "Chocolate Bar"
                },
                new Product()
                {
                    Name = "Perfume"
                },
                new Product()
                {
                    Name = "Packet of Headache pills"
                },
                new Product()
                {
                    Name = "Box of Chocolates"
                }
            };
        }

        /// <summary>
        /// Gets the product names
        /// </summary>
        /// <returns>A list of strings</returns>
        public List<string> GetProductNames()
        {
            return this.products.Select(x => x.Name).ToList();
        }

        /// <summary>
        /// Gets the product by id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A product</returns>
        public Product GetProductById(int id)
        {
            return this.products.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Gets the products by ids
        /// </summary>
        /// <param name="ids">The ids</param>
        /// <returns>A list of products</returns>
        public List<Product> GetProductsByIds(List<int> ids)
        {
            return this.products.Where(x => ids.Contains(x.Id)).ToList();
        }

        /// <summary>
        /// Gets all the products
        /// </summary>
        /// <returns>A list of products</returns>
        public List<Product> GetAllProducts()
        {
            return this.products;
        }
    }
}
