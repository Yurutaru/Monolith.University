using Microsoft.AspNetCore.Mvc;
using Monolith.University.API.Dto;

namespace Monolith.University.API.Swagger
{
    public class ProducesBadRequestAttribute : ProducesResponseTypeAttribute
    {
        public ProducesBadRequestAttribute() : base(typeof(ErrorResult), StatusCodes.Status400BadRequest)
        {
        }
    }
}
