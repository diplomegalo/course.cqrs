using System.Collections.Generic;
using System.Linq;
using Delsoft.Course.CQRS.Domain.Commands;
using Delsoft.Course.CQRS.Domain.Queries;
using Microsoft.AspNetCore.Mvc;
using Delsoft.Course.CQRS.Model.Commands;
using Delsoft.Course.CQRS.Model.Queries;
using Microsoft.AspNetCore.Http;

namespace Delsoft.Course.CQRS.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WineController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public WineController(ICommandBus commandBus, IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public void RegisterWine(Model.Dtos.RegisterWine registerWine)
        {
            _commandBus.Dispatch(new RegisterWine().From(registerWine));
        }

        [HttpGet]
        public ActionResult GetListOfWine(int millesime, string appellation)
        {
            var result = _queryBus.Dispatch(new GetListOfWinesQuery(millesime, appellation));
            return this.Ok(result.Select(wine => new Model.Dtos.Wine() { Appellation = wine.Appellation, Millesime = wine.Millesime, Name = wine.Name }));
        }
    }
}