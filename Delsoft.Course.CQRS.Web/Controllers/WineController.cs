using Delsoft.Course.CQRS.Domain.Commands;
using Microsoft.AspNetCore.Mvc;
using Delsoft.Course.CQRS.Model.Commands;
using Microsoft.AspNetCore.Http;

namespace Delsoft.Course.CQRS.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WineController : ControllerBase
    {
        private readonly ICommandBus _commandBus;

        public WineController(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public void RegisterWine(Model.Dtos.RegisterWine registerWine)
        {
            _commandBus.Dispatch(new RegisterWine().From(registerWine));
        }
    }
}