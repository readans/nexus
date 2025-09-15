using Infrastructure.Persistence.Extensions;

namespace Infrastructure.Persistence.Repositories;

public interface IRepository<T> where T : class
{
    // CRUD Básico
    Task<T?> GetByIdAsync<TId>(TId id) where TId : notnull;
    Task<List<T>> ListAllAsync();
    Task<T> AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities); 
    void Update(T entity);
    void Delete(T entity);
    
    // Specifications
    Task<T?> FirstOrDefaultAsync(ISpecification<T> specification);
    Task<List<T>> ListAsync(ISpecification<T> specification);
    Task<int> CountAsync(ISpecification<T> specification);
    Task<bool> AnyAsync(ISpecification<T> specification);
    
    // Queries personalizadas
    IQueryable<T> AsQueryable();
}
