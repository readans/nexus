namespace Infrastructure.Persistence.Repositories;

public interface IUnitOfWork : IDisposable
{
    IRepository<T> Repository<T>() where T : class;
    Task<int> CompleteAsync();
    void Rollback();
    Task ExecuteInTransactionAsync(Func<Task> action);
}
