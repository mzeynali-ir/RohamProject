using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Common
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class RootController : ControllerBase
    {
        protected int UserId => 1;//TODO load from TOKEN
    }
}
