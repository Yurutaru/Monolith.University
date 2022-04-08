using Monolith.University.Core.Contracts.Dto.Faculties;
using Monolith.University.Core.Mappers.Interfaces;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Core.Mappers
{
    public class FacultyMapper : IFacultyMapper
    {
        public Faculty Map(CreateFacultyRequest source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var result = new Faculty()
            {
                Name = source.Name,
            };

            return result;
        }

        public FacultyResponse Map(Faculty source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var result = new FacultyResponse()
            {
                Id = source.Id,
                Name = source.Name,
            };

            return result;
        }
    }
}
