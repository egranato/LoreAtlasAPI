using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LoreAtlas.Domain;
using LoreAtlas.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LoreAtlas.Application.Universes
{
  public class UniverseList
  {
    public class Query : IRequest<List<Universe>> { }

    public class Handler : IRequestHandler<Query, List<Universe>>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }

      public async Task<List<Universe>> Handle(Query request, CancellationToken cancellationToken)
      {
        return await _context.Universes.ToListAsync();
      }
    }
  }
}