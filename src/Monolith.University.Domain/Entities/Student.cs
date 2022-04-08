namespace Monolith.University.Domain.Entities
{
    public class Student : Person
    {
        public Faculty? Faculty { get; set; }
        public long FacultyId { get; set; }

        public Course? Course { get; set; }
        public long CourseId { get; set; }

        public Group? Group { get; set; }
        public long GroupId { get; set; }

        public Specialization? Specialization { get; set; }
        public long SpecializationId { get; set; }

        public StudentCard? StudentCard { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
