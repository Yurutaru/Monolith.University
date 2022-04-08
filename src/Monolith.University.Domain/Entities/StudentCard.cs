using Monolith.University.Domain.Entities.Interfaces;
using Monolith.University.Domain.Enums;
using Monolith.University.Domain.Records;

namespace Monolith.University.Domain.Entities
{
    public class StudentCard : IEntity<long>
    {
        public long Id { get; set; }

        public FullName? StudentCardFullName { get; set; }

        public Student? Student { get; set; }
        public long StudentId { get; set; }

        public Faculty? Faculty { get; set; }
        public long FacultyId { get; set; }

        public EducationForm EducationForm { get; set; }

        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
    }
}
