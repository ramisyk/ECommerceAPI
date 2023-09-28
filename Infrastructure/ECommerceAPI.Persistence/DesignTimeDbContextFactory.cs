using ECommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ECommerceAPI.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ECommerceAPIDbContext>
    {
        /// <summary>
        /// This class and method are created for migrations by dotnet cli
        /// </summary>
        /// <param name="args"></param>
        /// <returns>It returns DbContext with options known by dotnet cli commands</returns>
        public ECommerceAPIDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ECommerceAPIDbContext> optionsBuilder = new();
           // optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            optionsBuilder.UseNpgsql(Configuration.ConnectionString);
            return new(optionsBuilder.Options);
        }
    }
}
