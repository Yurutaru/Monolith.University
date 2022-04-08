using Monolith.University.Core.Helpers.Interfaces;

namespace Monolith.University.Core.Helpers
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTimeOffset GetUtcNow()
        {
            var result = DateTimeOffset.UtcNow;
            return result;
        }
    }
}
