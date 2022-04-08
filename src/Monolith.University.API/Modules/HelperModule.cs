using Autofac;
using Monolith.University.Core.Helpers;
using Monolith.University.Core.Helpers.Interfaces;

namespace Monolith.University.API.Modules
{
    public class HelperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DateTimeProvider>().As<IDateTimeProvider>().InstancePerLifetimeScope();
        }
    }
}
