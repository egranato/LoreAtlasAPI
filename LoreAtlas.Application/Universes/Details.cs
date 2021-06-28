using System;
using System.Threading;
using System.Threading.Tasks;
using LoreAtlas.Application.Core;
using LoreAtlas.Domain;
using LoreAtlas.Persistence;
using MediatR;

namespace LoreAtlas.Application.Universes
{
  public class UniverseDetails
  {
    public class Query : IRequest<Result<Universe>>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<Universe>>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }

      public async Task<Result<Universe>> Handle(Query request, CancellationToken cancellationToken)
      {
        var universe = await _context.Universes.FindAsync(request.Id);

        return Result<Universe>.Success(universe);
      }
    }
  }
}