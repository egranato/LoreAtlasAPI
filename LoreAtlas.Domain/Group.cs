using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoreAtlas.Domain
{
  public enum GroupType
  {
    Faction,
    Race
  }
  public class Group : BaseEntity
  {
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }
    public string Description { get; set; }

    [Required]
    public GroupType Type { get; set; }

    [Required]
    [ForeignKey("Universe")]
    public Guid UniverseId { get; set; }
    public Universe Universe { get; set; }
  }
}