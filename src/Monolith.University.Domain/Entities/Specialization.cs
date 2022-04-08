using Monolith.University.Domain.Entities.Interfaces;

namespace Monolith.University.Domain.Entities;

public class Specialization : IEntity<long>
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public decimal Duration { get; set; }

    public Faculty? Faculty { get; set; }
    public long FacultyId { get; set; }

    public ICollection<Student> Students { get; set; } = new List<Student>();

}
