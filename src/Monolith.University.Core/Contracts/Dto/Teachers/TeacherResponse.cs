using Monolith.University.Core.Contracts.Dto.People;
using Monolith.University.Core.Contracts.Dto.TeacherCard;

namespace Monolith.University.Core.Contracts.Dto.Teachers
{
    public class TeacherResponse : PersonResponse
    {
        public TeacherCardResponse? TeacherCard { get; set; }
    }
}
