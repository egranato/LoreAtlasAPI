using System.Threading;
using System.Threading.Tasks;
using LoreAtlas.Domain;
using LoreAtlas.Persistence;
using MediatR;

namespace LoreAtlas.Application.Universes
{
  public class UniverseCreate
  {
    public class Command : IRequest
    {
      public Universe Universe { get; set; }
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
        _context.Universes.Add(request.Universe);

        await _context.SaveChangesAsync();

        return Unit.Value;
      }
    }
  }
}