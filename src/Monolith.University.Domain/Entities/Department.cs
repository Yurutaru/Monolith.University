using Monolith.University.Domain.Entities.Interfaces;

namespace Monolith.University.Domain.Entities;

public class Department : IEntity<long>
{
    public long Id { get; set; }
    public string? Name { get; set; }

    public Faculty? Faculty { get; set; }
    public long FacultyId { get; set; }

    public ICollection<Teacher> Teacher { get; set; } = new List<Teacher>();
    public ICollection<TeacherCard> TeacherCards { get; set; } = new List<TeacherCard>();
}