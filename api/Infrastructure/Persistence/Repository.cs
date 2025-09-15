using Infrastructure.Persistence.Extensions;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class Repository<T>(DbContext context) : IRepository<T>
    where T : class
{
    private readonly DbContext _context = context;
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task<T?> GetByIdAsync<TId>(TId id) where TId : notnull
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<List<T>> ListAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> FirstOrDefaultAsync(ISpecification<T> specification)
    {
        return await ApplySpecification(specification).FirstOrDefaultAsync();
    }

    public async Task<List<T>> ListAsync(ISpecification<T> specification)
    {
        return await ApplySpecification(specification).ToListAsync();
    }

    public async Task<int> CountAsync(ISpecification<T> specification)
    {
        return await ApplySpecification(specification, true).CountAsync();
    }

    public async Task<bool> AnyAsync(ISpecification<T> specification)
    {
        return await ApplySpecification(specification, true).AnyAsync();
    }

    public IQueryable<T> AsQueryable()
    {
        return _dbSet.AsQueryable();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }
    
    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> specification, bool forCount = false)
    {
        return SpecificationEvaluator.Default.GetQuery(_dbSet, specification, forCount);
    }
}
