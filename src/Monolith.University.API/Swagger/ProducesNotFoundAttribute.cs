using Microsoft.AspNetCore.Mvc;
using Monolith.University.API.Dto;

namespace Monolith.University.API.Swagger
{
    public class ProducesNotFoundAttribute : ProducesResponseTypeAttribute
    {
        public ProducesNotFoundAttribute() : base(typeof(ErrorResult), StatusCodes.Status404NotFound)
        {
        }
    }
}
