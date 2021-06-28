using System.Threading;
using System.Threading.Tasks;
using LoreAtlas.Domain;
using LoreAtlas.Persistence;
using MediatR;
using AutoMapper;
using LoreAtlas.Application.Core;

namespace LoreAtlas.Application.Universes
{
  public class UniverseEdit
  {
    public class Command : IRequest<Result<Unit>>
    {
      public Universe Universe { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;
      }

      public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
      {
        var universe = await _context.Universes.FindAsync(request.Universe.Id);

        if (universe == null)
        {
          return null;
        }

        _mapper.Map(request.Universe, universe);

        return await _context.SaveChangesAsync() > 0
          ? Result<Unit>.Success(Unit.Value)
          : Result<Unit>.Failure("Failed to update universe");
      }
    }
  }
}