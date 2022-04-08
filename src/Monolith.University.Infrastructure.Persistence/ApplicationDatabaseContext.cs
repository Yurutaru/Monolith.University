using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Monolith.University.Domain.Entities;
using Monolith.University.Infrastructure.Persistence.Extensions;
using Monolith.University.Infrastructure.Persistence.Settings;
using System.Reflection;

namespace Monolith.University.Infrastructure.Persistence
{
    public class ApplicationDatabaseContext : DbContext
    {
        public DbSet<Department>? Departments { get; set; }
        public DbSet<Faculty>? Faculties { get; set; }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Group>? Groups { get; set; }
        public DbSet<Person>? People { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<Teacher>? Teachers { get; set; }
        public DbSet<StudentCard>? StudentCards { get; set; }
        public DbSet<TeacherCard>? TeacherCards { get; set; }

        private readonly DatabaseSettings settings;

        public ApplicationDatabaseContext(IOptions<DatabaseSettings> settings)
        {
            this.settings = settings?.Value ?? throw new ArgumentNullException(nameof(settings));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = settings?.ConnectionString ?? throw new ArgumentNullException(nameof(settings.ConnectionString));
            optionsBuilder
                .UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EntityEnumConfigurationExtensions.RegisterEnums(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
