namespace Monolith.University.Domain.Interfaces;

public interface IUnitOfWorkFactory
{
    IUnitOfWork BeginTransaction();
}