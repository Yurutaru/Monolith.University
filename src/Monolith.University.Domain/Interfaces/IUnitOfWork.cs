namespace Monolith.University.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task CommitAsync();
    Task RollbackAsync();
}