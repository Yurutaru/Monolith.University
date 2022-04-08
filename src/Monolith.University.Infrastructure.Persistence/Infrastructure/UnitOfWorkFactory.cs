using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Monolith.University.Domain.Interfaces;

namespace Monolith.University.Infrastructure.Persistence.Infrastructure
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IServiceProvider serviceProvider;

        public UnitOfWorkFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IUnitOfWork BeginTransaction()
        {
            var dbContext = serviceProvider.GetService<DbContext>();

            if(dbContext is null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            var result = new UnitOfWork(dbContext);
            return result;
        }
    }
}
