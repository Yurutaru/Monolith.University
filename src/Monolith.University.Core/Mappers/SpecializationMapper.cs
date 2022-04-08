using Monolith.University.Core.Contracts.Dto.Specializations;
using Monolith.University.Core.Mappers.Interfaces;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Core.Mappers
{
    public class SpecializationMapper : ISpecializationMapper
    {
        public Specialization Map(CreateSpecializationRequest source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var result = new Specialization()
            {
                Name = source.Name,
                Duration = source.Duration,
                FacultyId = source.FacultyId
                
            };

            return result;
        }

        public SpecializationResponse Map(Specialization source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var result = new SpecializationResponse()
            {
                Id = source.Id,
                Name = source.Name,
                Duration = source.Duration,

            };

            return result;
        }
    }
}
