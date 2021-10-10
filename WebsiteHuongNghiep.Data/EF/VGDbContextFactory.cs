using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteHuongNghiep.Data.EF
{
    public class VGDbContextFactory : IDesignTimeDbContextFactory<VocationalGuidanceDbContext>
    {
        public VocationalGuidanceDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("vocationalGuidanceDb");

            var optionBuilder = new DbContextOptionsBuilder<VocationalGuidanceDbContext>();
            optionBuilder.UseSqlServer(connectionString);

            return new VocationalGuidanceDbContext(optionBuilder.Options);
        }
    }
}
