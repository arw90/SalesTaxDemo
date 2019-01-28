// <copyright file="ProductController.cs" company="None">
// None
// </copyright>

namespace SalesTaxStore.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using SalesTaxStore.Models;
    using SalesTaxStore.Services;

    /// <summary>
    /// The product controller
    /// </summary>
    public class ProductController : Controller
    {
        /// <summary>
        /// The product service
        /// </summary>
        private IProductService productService;

        /// <summary>
        /// The cart service
        /// </summary>
        private IShoppingCartService cartService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class
        /// </summary>
        /// <param name="productService">The product service</param>
        /// <param name="cartService">The cart services</param>
        public ProductController(IProductService productService, IShoppingCartService cartService)
        {
            this.productService = productService;
            this.cartService = cartService;
        }

        /// <summary>
        /// Loads the home view
        /// </summary>
        /// <returns>A view result</returns>
        [HttpGet]
        public IActionResult Index()
        {
            // Populate the select list in the view without creating a needlessly complex view model
            ViewBag.ProductNames = this.productService.GetProductNames();

            return this.View();
        }

        /// <summary>
        /// Handles the submitted products
        /// </summary>
        /// <param name="submittedProducts">The submitted products</param>
        /// <returns>A view result</returns>
        [HttpPost]
        public IActionResult Index(List<Product> submittedProducts)
        {
            /* This is intentionally a small hack - since we have a static number of UI inputs we want to filter out the empty submission fields 
            and only validate the ones the user did submit - no time to build a more dynamic UI but it will still demonstrate validation errors. */
            var populatedProducts = submittedProducts.Where(x => x.Quantity > 0 || x.BasePrice != 0).ToList();

            ModelState.Clear();  // TryValidateModel is additive, so remove all the false alarms first
            if (this.TryValidateModel(populatedProducts))
            {
                this.cartService.AddProductsToCart(populatedProducts);

                return this.RedirectToAction("Index", "Cart", null);
            }

            // Need to repopulate the select list in the view for page reload
            ViewBag.ProductNames = this.productService.GetProductNames();
            return this.View();
        }
    }
}
