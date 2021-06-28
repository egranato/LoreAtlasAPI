using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LoreAtlas.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LoreAtlas.Persistence
{
  public class DataContext : IdentityDbContext<User>
  {
    public DataContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.Entity<User>()
        .HasMany(u => u.Universes)
        .WithOne(u => u.Owner)
        .IsRequired();

      builder.Entity<Universe>()
        .HasMany(u => u.Events)
        .WithOne(e => e.Universe)
        .IsRequired();

      builder.Entity<Universe>()
      .HasMany(u => u.Narratives)
      .WithOne(n => n.Universe)
      .IsRequired();

      builder.Entity<Universe>()
      .HasMany(u => u.Characters)
      .WithOne(c => c.Universe)
      .IsRequired();

      builder.Entity<Universe>()
      .HasMany(u => u.Groups)
      .WithOne(g => g.Universe)
      .IsRequired();

      builder.Entity<Universe>()
      .HasMany(u => u.Places)
      .WithOne(p => p.Universe)
      .IsRequired();

      builder.Entity<Universe>()
      .HasMany(u => u.Items)
      .WithOne(i => i.Universe)
      .IsRequired();
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
    public DbSet<Event> Events { get; set; }
    public DbSet<Narrative> Narratives { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Place> Places { get; set; }
    public DbSet<Item> Items { get; set; }
  }
}