using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace seoShopSolution.Data.EF
{
    public class seoShopSolutionDbContextFactory : IDesignTimeDbContextFactory<seoShopSolutionDbContext>
    {
        public seoShopSolutionDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("seoShopSolutionDb");

            var optionsBuilder = new DbContextOptionsBuilder<seoShopSolutionDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new seoShopSolutionDbContext(optionsBuilder.Options);
        }
    }
}
