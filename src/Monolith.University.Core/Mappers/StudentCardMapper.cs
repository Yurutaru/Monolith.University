using Monolith.University.Core.Contracts.Dto.StudentCards;
using Monolith.University.Core.Mappers.Interfaces;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Core.Mappers
{
    public class StudentCardMapper : IStudentCardMapper
    {
        public StudentCardResponse Map(StudentCard source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var result = new StudentCardResponse() 
            { 
                Id = source.Id
            };

            return result;
        }
    }
}
