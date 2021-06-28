using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LoreAtlas.Application.Core;
using LoreAtlas.Domain;
using LoreAtlas.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LoreAtlas.Application.Universes
{
  public class UniverseList
  {
    public class Query : IRequest<Result<List<Universe>>> { }

    public class Handler : IRequestHandler<Query, Result<List<Universe>>>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }

      public async Task<Result<List<Universe>>> Handle(Query request, CancellationToken cancellationToken)
      {
        return Result<List<Universe>>.Success(await _context.Universes.ToListAsync());
      }
    }
  }
}