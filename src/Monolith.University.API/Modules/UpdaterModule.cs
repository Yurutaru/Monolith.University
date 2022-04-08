using Autofac;
using Monolith.University.Core.Updaters;
using Monolith.University.Core.Updaters.Interfaces;
using Monolith.University.Domain.Enums;

namespace Monolith.University.API.Modules
{
    public class UpdaterModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DepartmentUpdater>().As<IDepartmentUpdater>().InstancePerLifetimeScope();
            builder.RegisterType<FacultyUpdater>().As<IFacultyUpdater>().InstancePerLifetimeScope();
            builder.RegisterType<CourseUpdater>().As<ICourseUpdater>().InstancePerLifetimeScope();
            builder.RegisterType<GroupUpdater>().As<IGroupUpdater>().InstancePerLifetimeScope();

            builder.RegisterType<SpecializationUpdater>().As<ISpecializationUpdater>().InstancePerLifetimeScope();

            builder.RegisterType<StudentUpdater>().Keyed<IPersonUpdater>(PersonDiscriminator.Student);
            builder.RegisterType<TeacherUpdater>().Keyed<IPersonUpdater>(PersonDiscriminator.Teacher);

            builder.RegisterType<TicketUpdater>().As<ITicketUpdater>().InstancePerLifetimeScope();
        }
    }
}
