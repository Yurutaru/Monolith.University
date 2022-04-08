using Monolith.University.Domain.Entities.Interfaces;

namespace Monolith.University.Domain.Entities;

public class Group : IEntity<long>
{
    public long Id { get; set; }
    public string? Name { get; set; }
    
    public Faculty? Faculty { get; set; }
    public long FacultyId { get; set; }

    public Course? Course { get; set; }
    public long CourseId { get; set; }

    public ICollection<Student> Students { get; set; } = new List<Student>();
}
