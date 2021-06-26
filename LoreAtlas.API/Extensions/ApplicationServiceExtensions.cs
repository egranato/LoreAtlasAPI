using LoreAtlas.Application.Universes;
using LoreAtlas.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using LoreAtlas.Application.Core;

namespace LoreAtlas.API.Extensions
{
  public static class ApplicationServiceExtensions
  {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "LoreAtlas.API", Version = "v1" });
      });

      services.AddDbContext<DataContext>(opt =>
      {
        opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
      });

      services.AddCors(opt =>
      {
        opt.AddPolicy("CorsPolicy", policy =>
        {
          policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:4200");
        });
      });

      services.AddMediatR(typeof(UniverseList.Handler).Assembly);
      services.AddAutoMapper(typeof(MappingProfiles).Assembly);

      return services;
    }
  }
}