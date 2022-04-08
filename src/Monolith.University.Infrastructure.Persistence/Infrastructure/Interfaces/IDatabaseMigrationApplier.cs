namespace Monolith.University.Infrastructure.Persistence.Infrastructure.Interfaces
{
    public interface IDatabaseMigrationApplier
    {
        void ApplyMigrations();
    }
}
