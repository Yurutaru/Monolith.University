using Monolith.University.Domain.Entities.Interfaces;
using Monolith.University.Domain.Records;

namespace Monolith.University.Domain.Entities
{
    public class TeacherCard : IEntity<long>
    {
        public long Id { get; set; }

        public FullName? TeacherCardFullName { get; set; }

        public Teacher? Teacher { get; set; }
        public long TeacherId { get; set; }

        public long FacultyId { get; set; }
        public Faculty? Faculty { get; set; }

        public long DepartmentId { get; set; }
        public Department? Department { get; set; }

        public DateTimeOffset? StartDate { get; set; }
    }
}
