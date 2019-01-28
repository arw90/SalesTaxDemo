// <copyright file="Program.cs" company="None">
// None
// </copyright>

namespace SalesTaxStore
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;

    /// <summary>
    /// The program class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main method
        /// </summary>
        /// <param name="args">The args</param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// The web hose
        /// </summary>
        /// <param name="args">The args</param>
        /// <returns>A web host</returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
