using Monolith.University.Domain.Entities.Interfaces;

namespace Monolith.University.Domain.Entities;

public class Course : IEntity<long>
{
    public long Id { get; set; }
    public string? Name { get; set; }

    public long FacultyId { get; set; }
    public Faculty? Faculty { get; set; }

    public ICollection<Group> Groups { get; set; } = new List<Group>();
    public ICollection<Student> Students { get; set; } = new List<Student>();
}
