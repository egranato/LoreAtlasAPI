using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoreAtlas.Domain
{
  public class Character : BaseEntity
  {
    [Key]
    public Guid Id { get; set; }

    // , delimited list of names e.g. Harry,James,Potter
    [Required]
    public string Name { get; set; }

    [Required]
    [ForeignKey("Universe")]
    public Guid UniverseId { get; set; }
    public Universe Universe { get; set; }
  }
}