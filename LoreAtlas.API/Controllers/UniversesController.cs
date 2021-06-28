using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LoreAtlas.Application.Universes;
using LoreAtlas.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoreAtlas.API.Controllers
{
  [Authorize]
  public class UniversesController : BaseApiController
  {
    [HttpGet]
    public async Task<ActionResult<List<Universe>>> GetUniverses()
    {
      return HandleResult(await Mediator.Send(new UniverseList.Query()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUniverse(Guid id)
    {
      var query = new UniverseDetails.Query { Id = id };
      var result = await Mediator.Send(query);

      return HandleResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUniverse(Universe universe)
    {
      var command = new UniverseCreate.Command { Universe = universe };
      return HandleResult(await Mediator.Send(command));
    }

    [Route("{id}")]
    [AcceptVerbs("PUT,PATCH")]
    public async Task<IActionResult> EditUniverse(Guid id, Universe universe)
    {
      universe.Id = id;
      var command = new UniverseEdit.Command { Universe = universe };
      return HandleResult(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUniverse(Guid id)
    {
      var command = new UniverseDelete.Command { Id = id };
      return HandleResult(await Mediator.Send(command));
    }
  }
}