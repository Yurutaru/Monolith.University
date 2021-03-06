namespace Monolith.University.Domain.Entities.Interfaces;

public interface IAuditable
{
    DateTimeOffset? CreatedAt { get; set; }
    DateTimeOffset? UpdatedAt { get; set; }
}
