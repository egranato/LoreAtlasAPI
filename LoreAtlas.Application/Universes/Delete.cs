using System;
using System.Threading;
using System.Threading.Tasks;
using LoreAtlas.Application.Core;
using LoreAtlas.Persistence;
using MediatR;

namespace LoreAtlas.Application.Universes
{
  public class UniverseDelete
  {
    public class Command : IRequest<Result<Unit>>
    {
      public Guid Id { get; set; }
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
        var universe = await _context.Universes.FindAsync(request.Id);

        if (universe == null)
        {
          return null;
        }

        _context.Remove(universe);

        return await _context.SaveChangesAsync() > 0
          ? Result<Unit>.Success(Unit.Value)
          : Result<Unit>.Failure("Failed to delete the universe");
      }
    }
  }
}