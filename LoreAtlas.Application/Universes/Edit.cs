using System.Threading;
using System.Threading.Tasks;
using LoreAtlas.Domain;
using LoreAtlas.Persistence;
using MediatR;
using AutoMapper;

namespace LoreAtlas.Application.Universes
{
  public class UniverseEdit
  {
    public class Command : IRequest
    {
      public Universe Universe { get; set; }
    }

    public class Handler : IRequestHandler<Command>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;
      }

      public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
      {
        var universe = await _context.Universes.FindAsync(request.Universe.Id);

        _mapper.Map(request.Universe, universe);

        await _context.SaveChangesAsync();

        return Unit.Value;
      }
    }
  }
}