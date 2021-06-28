using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoreAtlas.Domain
{
  public class Event : BaseEntity
  {
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }
    public string Description { get; set; }

    public int Date { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }

    [Required]
    [ForeignKey("Universe")]
    public Guid UniverseId { get; set; }
    public Universe Universe { get; set; }
  }
}