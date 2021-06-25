using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LoreAtlas.Domain;
using Microsoft.EntityFrameworkCore;

namespace LoreAtlas.Persistence
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions options) : base(options)
    {

    }

    private void SetEntityDates()
    {
      var entries = ChangeTracker
        .Entries()
        .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

      foreach (var entityEntry in entries)
      {
        ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.Now;

        if (entityEntry.State == EntityState.Added)
        {
            ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
        }
      }
    }

    public override int SaveChanges()
    {
      SetEntityDates();
      return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
      SetEntityDates();
      return (await base.SaveChangesAsync(true, cancellationToken));
    }

    public DbSet<Universe> Universes { get; set; }
  }
}