using Microsoft.AspNetCore.Mvc;

namespace Monolith.University.API.Swagger
{
    public class ProducesCreatedAttribute : ProducesResponseTypeAttribute
    {
        public ProducesCreatedAttribute(Type responseType) : base(responseType, StatusCodes.Status201Created)
        {
        }
    }
}
