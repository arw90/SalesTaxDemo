// <copyright file="ShoppingCartService.cs" company="None">
// None
// </copyright>

namespace SalesTaxStore.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using SalesTaxStore.Models;

    /// <summary>
    /// The shopping cart service
    /// </summary>
    public class ShoppingCartService : IShoppingCartService
    {
        /// <summary>
        /// The items in the cart
        /// </summary>
        private List<Product> itemsInCart = new List<Product>();

        /// <summary>
        /// The sales tax service
        /// </summary>
        private ITaxService<SalesTaxService> salesTaxeService;

        /// <summary>
        /// The import tax service
        /// </summary>
        private ITaxService<ImportTaxService> importTaxService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCartService"/> class
        /// </summary>
        /// <param name="salesTaxService">The sales tax service</param>
        /// <param name="importTaxService">The import tax service</param>
        public ShoppingCartService(ITaxService<SalesTaxService> salesTaxService, ITaxService<ImportTaxService> importTaxService)
        {
            this.salesTaxeService = salesTaxService;
            this.importTaxService = importTaxService;
        }

        /// <summary>
        /// Adds multiple products to cart
        /// </summary>
        /// <param name="products">The products</param>
        public void AddProductsToCart(List<Product> products)
        {
            // For simplicity let's just clear this every time for now since it's registered as a singleton to simulate state
            this.itemsInCart.Clear();

            this.itemsInCart.AddRange(products);
        }

        /// <summary>
        /// Adds one product to cart
        /// </summary>
        /// <param name="product">The product</param>
        public void AddProductToCart(Product product)
        {
            this.itemsInCart.Add(product);
        }

        /// <summary>
        /// Generates a receipt
        /// </summary>
        /// <returns>The Receipt</returns>
        public Receipt GenerateCheckoutReceipt()
        {
            // Update the products with taxes
            var itemsWithSalesTax = this.salesTaxeService.CalculateTaxForItems(this.itemsInCart);
            var itemsWithImportTax = this.importTaxService.CalculateTaxForItems(itemsWithSalesTax);
            var itemsWithFinalPrices = this.CalculateFinalTaxedPrice(itemsWithImportTax);

            // Create the line items
            var receiptLineItems = this.GenerateReceiptLineItems(itemsWithFinalPrices);

            // Get the overall totals
            var totalPrice = itemsWithFinalPrices.Select(x => x.FinalPrice).Sum();
            var totalSalesTax = itemsWithFinalPrices.Select(x => x.SalesTax).Sum();
            var totalImportTax = itemsWithFinalPrices.Select(x => x.ImportTax).Sum();

            // Assemble final receipt object
            var receipt = new Receipt()
            {
                PurchasedProducts = receiptLineItems,
                TotalPrice = totalPrice,
                TotalSalesTax = totalSalesTax + totalImportTax
            };

            return receipt;
        }

        /// <summary>
        /// Generates the line items
        /// </summary>
        /// <param name="products">The products</param>
        /// <returns>A list of receipt line items</returns>
        private List<ReceiptLineItem> GenerateReceiptLineItems(List<Product> products)
        {
            // Grouping by name helps us figure out how to show line items for multiple of the same type of product
            var itemsGroupedByName = products.OrderBy(x => x.Name).GroupBy(x => x.Name);

            var receiptLineItems = new List<ReceiptLineItem>();

            foreach (var group in itemsGroupedByName)
            {
                // This handles the grouping on the receipt if there are multiple items and all or none are imported
                if ((group.All(x => x.IsImported) || group.All(x => !x.IsImported)) && group.Count() > 1)
                {
                    var lineItem = new ReceiptLineItem();
                    var first = group.FirstOrDefault();
                    lineItem.ProductName = first.Name;
                    lineItem.IsImported = first.IsImported;
                    lineItem.ProductPrice = first.FinalPrice * group.Count();
                    lineItem.QuantityLabel = "(" + group.Count() + " @ " + (lineItem.ProductPrice / group.Count()) + ")";

                    receiptLineItems.Add(lineItem);
                }
                else
                {
                    // This handles multiple group items where some are imported and some are not - just make a line item for each
                    foreach (var item in group)
                    {
                        var lineItem = new ReceiptLineItem();
                        lineItem.ProductName = item.Name;
                        lineItem.IsImported = item.IsImported;
                        lineItem.ProductPrice = item.FinalPrice * item.Quantity;

                        receiptLineItems.Add(lineItem);
                    }
                }
            }

            return receiptLineItems;
        }

        /// <summary>
        /// Calculates the final price
        /// </summary>
        /// <param name="products">The products</param>
        /// <returns>A list of products</returns>
        private List<Product> CalculateFinalTaxedPrice(List<Product> products)
        {
            foreach (var product in products)
            {
                product.FinalPrice = product.BasePrice + product.SalesTax + product.ImportTax;
            }

            return products;
        }
    }
}
