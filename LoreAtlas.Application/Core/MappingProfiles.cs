using AutoMapper;
using LoreAtlas.Domain;

namespace LoreAtlas.Application.Core
{
  public class MappingProfiles : Profile
  {
    public MappingProfiles()
    {
      CreateMap<Universe, Universe>();
    }
  }
}