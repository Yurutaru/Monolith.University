using Autofac;
using Monolith.University.Core.Mappers;
using Monolith.University.Core.Mappers.Interfaces;
using Monolith.University.Domain.Enums;

namespace Monolith.University.API.Modules
{
    public class MappingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DepartmentMapper>().As<IDepartmentMapper>().InstancePerLifetimeScope();
            builder.RegisterType<FacultyMapper>().As<IFacultyMapper>().InstancePerLifetimeScope();
            builder.RegisterType<CourseMapper>().As<ICourseMapper>().InstancePerLifetimeScope();
            builder.RegisterType<GroupMapper>().As<IGroupMapper>().InstancePerLifetimeScope();

            builder.RegisterType<SpecializationMapper>().As<ISpecializationMapper>().InstancePerLifetimeScope();

            builder.RegisterType<StudentCardMapper>().As<IStudentCardMapper>().InstancePerLifetimeScope();
            builder.RegisterType<TeacherCardMapper>().As<ITeacherCardMapper>().InstancePerLifetimeScope();

            builder.RegisterType<StudentMapper>().Keyed<IPersonMapper>(PersonDiscriminator.Student);
            builder.RegisterType<TeacherMapper>().Keyed<IPersonMapper>(PersonDiscriminator.Teacher);

            builder.RegisterType<TicketMapper>().As<ITicketMapper>().InstancePerLifetimeScope();
        }
    }
}
