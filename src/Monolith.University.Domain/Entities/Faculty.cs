using Monolith.University.Domain.Entities.Interfaces;

namespace Monolith.University.Domain.Entities;

public class Faculty : IEntity<long>
{
    public long Id { get; set; }
    public string? Name { get; set; }

    public ICollection<Department> Departments { get; set; } = new List<Department>();
    public ICollection<Specialization> Specializations { get; set; } = new List<Specialization>();
    public ICollection<Course> Courses { get; set; } = new List<Course>();
    public ICollection<Group> Groups { get; set; } = new List<Group>();

    public ICollection<Student> Students { get; set; } = new List<Student>();
    public ICollection<StudentCard> StudentCards { get; set; } = new List<StudentCard>();
    public ICollection<Teacher> Teacher { get; set; } = new List<Teacher>();
    public ICollection<TeacherCard> TeacherCards { get; set; } = new List<TeacherCard>();

    // TODO: Add dean of faculty string or ref on 1 from instructor
}
