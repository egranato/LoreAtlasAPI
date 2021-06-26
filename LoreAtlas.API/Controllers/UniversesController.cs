using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LoreAtlas.Application.Universes;
using LoreAtlas.Domain;
using Microsoft.AspNetCore.Mvc;

namespace LoreAtlas.API.Controllers
{
  public class UniversesController : BaseApiController
  {
    [HttpGet]
    public async Task<ActionResult<List<Universe>>> GetUniverses()
    {
      return await Mediator.Send(new UniverseList.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Universe>> GetUniverse(Guid id)
    {
      var query = new UniverseDetails.Query { Id = id };

      return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUniverse(Universe universe)
    {
      var command = new UniverseCreate.Command { Universe = universe };

      return Ok(await Mediator.Send(command));
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> EditUniverse(Guid id, Universe universe)
    {
      universe.Id = id;
      var command = new UniverseEdit.Command { Universe = universe };
      return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUniverse(Guid id)
    {
      var command = new UniverseDelete.Command { Id = id };
      return Ok(await Mediator.Send(command));
    }
  }
}