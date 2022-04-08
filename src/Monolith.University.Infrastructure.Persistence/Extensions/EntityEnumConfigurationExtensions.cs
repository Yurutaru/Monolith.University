using Microsoft.EntityFrameworkCore;
using Monolith.University.Domain.Enums;
using Npgsql;

namespace Monolith.University.Infrastructure.Persistence.Extensions
{
    internal class EntityEnumConfigurationExtensions
    {
        public static void MapEnums()
        {
            NpgsqlConnection.GlobalTypeMapper.MapEnum<TicketStatus>();
            NpgsqlConnection.GlobalTypeMapper.MapEnum<EducationForm>();
            NpgsqlConnection.GlobalTypeMapper.MapEnum<PersonDiscriminator>();
        }

        public static void RegisterEnums(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum<TicketStatus>();
            modelBuilder.HasPostgresEnum<EducationForm>();
            modelBuilder.HasPostgresEnum<PersonDiscriminator>();
        }
    }
}
