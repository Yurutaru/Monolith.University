namespace Monolith.University.Core.Helpers.Interfaces
{
    public interface IDateTimeProvider
    {
        DateTimeOffset GetUtcNow();
    }
}
