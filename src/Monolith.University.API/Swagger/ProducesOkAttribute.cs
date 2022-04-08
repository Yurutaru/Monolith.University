using Microsoft.AspNetCore.Mvc;

namespace Monolith.University.API.Swagger
{
    public class ProducesOkAttribute : ProducesResponseTypeAttribute
    {
        public ProducesOkAttribute() : base(StatusCodes.Status200OK)
        {
        }

        public ProducesOkAttribute(Type responseType) : base(responseType, StatusCodes.Status200OK)
        {
        }
    }
}
