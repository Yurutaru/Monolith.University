using System.Collections.Generic;

namespace Monolith.University.Domain.Interfaces;

public interface IMapper<in TSource, out TDestination>
    where TSource : class
    where TDestination : class
{
    TDestination Map(TSource source);
    IEnumerable<TDestination> MapCollection(IEnumerable<TSource> source)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        var result = source.Select(t => Map(t)).ToArray();
        return result;
    }
}