using System.Threading;
using System.Threading.Tasks;
using LoreAtlas.Application.Core;
using LoreAtlas.Domain;
using LoreAtlas.Persistence;
using MediatR;

namespace LoreAtlas.Application.Universes
{
  public class UniverseCreate
  {
    public class Command : IRequest<Result<Unit>>
    {
      public Universe Universe { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }

      public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
      {
        _context.Universes.Add(request.Universe);

        return await _context.SaveChangesAsync() > 0
          ? Result<Unit>.Success(Unit.Value)
          : Result<Unit>.Failure("Failed to create universe");
      }
    }
  }
}