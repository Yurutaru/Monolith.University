using Microsoft.AspNetCore.Mvc;
using Monolith.University.API.Dto;

namespace Monolith.University.API.Swagger
{
    public class ProducesUnauthorizedAttribute : ProducesResponseTypeAttribute
    {
        public ProducesUnauthorizedAttribute() : base(typeof(ErrorResult), StatusCodes.Status401Unauthorized)
        {
        }
    }
}
