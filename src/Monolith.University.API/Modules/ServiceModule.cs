using Autofac;
using Monolith.University.Core.Services;
using Monolith.University.Core.Services.Interfaces;

namespace Monolith.University.API.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PersonService>().As<IPersonService>().InstancePerLifetimeScope();
            builder.RegisterType<StudentService>().As<IStudentService>().InstancePerLifetimeScope();
            builder.RegisterType<TeacherService>().As<ITeacherService>().InstancePerLifetimeScope();
            builder.RegisterType<DepartmentService>().As<IDepartmentService>().InstancePerLifetimeScope();
            builder.RegisterType<FacultyService>().As<IFacultyService>().InstancePerLifetimeScope();
            builder.RegisterType<CourseService>().As<ICourseService>().InstancePerLifetimeScope();
            builder.RegisterType<GroupService>().As<IGroupService>().InstancePerLifetimeScope();

            builder.RegisterType<SpecializationService>().As<ISpecializationService>().InstancePerLifetimeScope();

            builder.RegisterType<TicketService>().As<ITicketService>().InstancePerLifetimeScope();
        }
    }
}
