using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Monolith.University.Domain.Interfaces;

namespace Monolith.University.Infrastructure.Persistence.Infrastructure
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContextTransaction transaction;

        public UnitOfWork(DbContext applicationDatabaseContext)
        {
            transaction = applicationDatabaseContext.Database.BeginTransaction();
        }

        public async Task CommitAsync()
        {
            await transaction.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            await transaction.RollbackAsync();
        }

        public void Dispose()
        {
            transaction.Dispose();
        }
    }
}
