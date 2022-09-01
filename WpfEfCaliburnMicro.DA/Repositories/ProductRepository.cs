using WpfEfCaliburnMicro.Application.Interfaces;
using WpfEfCaliburnMicro.Domain.Entities;
using WpfEfCaliburnMicro.Persistence.Contexts;

namespace WpfEfCaliburnMicro.Persistence.Repositories
{
  public class ProductRepository : Repository<Product>, IProductRepository
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductRepository"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public ProductRepository(MyDbContext context) : base(context)
    {
    }
  }
}