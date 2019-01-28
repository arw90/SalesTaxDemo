// <copyright file="CartController.cs" company="None">
// Test
// </copyright>

namespace SalesTaxStore.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SalesTaxStore.Services;

    /// <summary>
    /// The cart controller
    /// </summary>
    public class CartController : Controller
    {
        /// <summary>
        /// The injected shopping cart service
        /// </summary>
        private IShoppingCartService cartService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CartController" /> class
        /// </summary>
        /// <param name="cartService">The cart service</param>
        public CartController(IShoppingCartService cartService)
        {
            this.cartService = cartService;
        }

        /// <summary>
        /// Shows the receipt view
        /// </summary>
        /// <returns>A View Result</returns>
        [HttpGet]
        public IActionResult Index()
        {
            return this.View(this.cartService.GenerateCheckoutReceipt());
        }
    }
}
