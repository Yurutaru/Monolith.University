using Autofac;
using Microsoft.EntityFrameworkCore;
using Monolith.News.Persistence.Repositories;
using Monolith.University.Domain.Interfaces;
using Monolith.University.Infrastructure.Persistence;
using Monolith.University.Infrastructure.Persistence.Infrastructure;
using Monolith.University.Infrastructure.Persistence.Infrastructure.Interfaces;

namespace Monolith.University.API.Modules
{
    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(EntityFrameworkRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWorkFactory>().As<IUnitOfWorkFactory>().InstancePerLifetimeScope();
            builder.RegisterType<ApplicationDatabaseContext>().As<DbContext>().InstancePerLifetimeScope();
            builder.RegisterType<DatabaseMigrationApplier>().As<IDatabaseMigrationApplier>().InstancePerLifetimeScope();
        }
    }
}
