namespace WpfEfCaliburnMicro.Application.Interfaces
{
  /// <summary>
  /// Interface IRepository
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public interface IRepository<T> where T : class
  {
    Task<T> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<IReadOnlyList<T>> GetPagedReponseAsync(int pageNumber, int pageSize);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
  }
}
