using System;
using System.Threading;
using System.Threading.Tasks;
using LoreAtlas.Persistence;
using MediatR;

namespace LoreAtlas.Application.Universes
{
  public class UniverseDelete
  {
    public class Command : IRequest
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Command>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }

      public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
      {
        var universe = await _context.Universes.FindAsync(request.Id);

        _context.Remove(universe);

        await _context.SaveChangesAsync();

        return Unit.Value;
      }
    }
  }
}