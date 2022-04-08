using Monolith.University.Core.Contracts.Dto.Courses;
using Monolith.University.Core.Contracts.Dto.Faculties;
using Monolith.University.Core.Contracts.Dto.Groups;
using Monolith.University.Core.Contracts.Dto.People;
using Monolith.University.Core.Contracts.Dto.Specializations;
using Monolith.University.Core.Contracts.Dto.StudentCards;
using Monolith.University.Core.Contracts.Dto.Tickets;

namespace Monolith.University.Core.Contracts.Dto.Students
{
    public class StudentResponse : PersonResponse
    {
        public FacultyResponse? Faculty { get; set; }
        public CourseResponse? Course { get; set; }
        public GroupResponse? Group { get; set; }
        public SpecializationResponse? Specialization { get; set; }
        public StudentCardResponse? StudentCard { get; set; }

        public ICollection<TicketResponse> Tickets { get; set; } = new List<TicketResponse>();
    }
}
