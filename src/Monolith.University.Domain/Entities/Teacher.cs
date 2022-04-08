namespace Monolith.University.Domain.Entities
{
    public class Teacher : Person
    {
        public long FacultyId { get; set; }
        public Faculty? Faculty { get; set; }

        public long DepartmentId { get; set; }
        public Department? Department { get; set; }

        public TeacherCard? TeacherCard { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
