using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BigBlueClothingFactory.Database
{
    public class StoreContextFactory : IDesignTimeDbContextFactory<StoreContext>
    {

        public StoreContext CreateDbContext(string[] args)
        {
            var configuraiton = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<StoreContext>();

            var connectiongString = configuraiton.GetConnectionString("BigBlueClothingFactoryDb");

            builder.UseSqlServer(connectiongString);

            return new StoreContext(builder.Options);
        }
    }
}
