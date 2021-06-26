using System;
using System.Threading;
using System.Threading.Tasks;
using LoreAtlas.Domain;
using LoreAtlas.Persistence;
using MediatR;

namespace LoreAtlas.Application.Universes
{
  public class UniverseDetails
  {
    public class Query : IRequest<Universe>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Universe>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }

      public async Task<Universe> Handle(Query request, CancellationToken cancellationToken)
      {
        return await _context.Universes.FindAsync(request.Id);
      }
    }
  }
}