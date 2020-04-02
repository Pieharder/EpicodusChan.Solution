using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace EpicodusChan.Models
{
  public class EpicodusChanContextFactory : IDesignTimeDbContextFactory<EpicodusChanContext>
  {
    EpicodusChanContext IDesignTimeDbContextFactory<EpicodusChanContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<EpicodusChanContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new EpicodusChanContext(builder.Options);
    }
  }
}