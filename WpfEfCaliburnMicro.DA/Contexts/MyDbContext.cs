using WpfEfCaliburnMicro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace WpfEfCaliburnMicro.Persistence.Contexts
{
  public class MyDbContext : DbContext
  {

    public MyDbContext() : base()
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      if (!builder.IsConfigured)
      { 
        builder.UseSqlServer(connectionString: 
          ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
      }
    }


    public DbSet<Product> Products => Set<Product>();
  }
}