using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LoreAtlas.Domain;
using LoreAtlas.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoreAtlas.API.Controllers
{
  public class UniversesController : ControllerBase
  {
    private readonly DataContext _context;
    public UniversesController(DataContext context)
    {
      _context = context;

    }

    [HttpGet]
    public async Task<ActionResult<List<Universe>>> GetUniverses()
    {
      return await _context.Universes.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Universe>> GetUniverse(Guid id)
    {
      return await _context.Universes.FindAsync(id);
    }
  }
}