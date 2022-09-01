using WpfEfCaliburnMicro.Application.Interfaces;
using WpfEfCaliburnMicro.Domain.Entities;
using WpfEfCaliburnMicro.Persistence.Contexts;

namespace WpfEfCaliburnMicro.Persistence.Repositories
{
  public class ErrorClassRepository : Repository<ErrorClassModel>, IErrorClassRepository
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ErrorClassRepository"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public ErrorClassRepository(MyDbContext context) : base(context)
    {
    }
  }
}