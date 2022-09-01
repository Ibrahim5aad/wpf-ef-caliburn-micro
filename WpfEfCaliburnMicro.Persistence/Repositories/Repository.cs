using WpfEfCaliburnMicro.Application.Interfaces;
using WpfEfCaliburnMicro.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace WpfEfCaliburnMicro.Persistence.Repositories
{
  public class Repository<T> : IRepository<T> where T : class
  {

    MyDbContext _dbContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="Repository{T}"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public Repository(MyDbContext context)
    {
      _dbContext = context;
    }

    public async Task<T> AddAsync(T entity)
    {
      await _dbContext.Set<T>().AddAsync(entity);
      await _dbContext.SaveChangesAsync();
      return entity;
    }

    public async Task DeleteAsync(T entity)
    {
      _dbContext.Set<T>().Remove(entity);
      await _dbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
      return await _dbContext
                .Set<T>()
                .ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
      return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> GetPagedReponseAsync(int pageNumber, int pageSize)
    {
      return await _dbContext
                      .Set<T>()
                      .Skip((pageNumber - 1) * pageSize)
                      .Take(pageSize)
                      .AsNoTracking()
                      .ToListAsync();
    }

    public async Task UpdateAsync(T entity)
    {
      _dbContext.Entry(entity).State = EntityState.Modified;
      await _dbContext.SaveChangesAsync();
    }
  }
}