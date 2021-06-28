using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoreAtlas.Domain
{
  public class Universe : BaseEntity
  {
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }
    public string Description { get; set; }

    [InverseProperty("Universe")]
    public ICollection<Event> Events { get; set; }

    [InverseProperty("Universe")]
    public ICollection<Narrative> Narratives { get; set; }

    [InverseProperty("Universe")]
    public ICollection<Character> Characters { get; set; }

    [InverseProperty("Universe")]
    public ICollection<Group> Groups { get; set; }

    [InverseProperty("Universe")]
    public ICollection<Place> Places { get; set; }

    [InverseProperty("Universe")]
    public ICollection<Item> Items { get; set; }

    [Required]
    [ForeignKey("User")]
    public string OwnerId { get; set; }
    public User Owner { get; set; }
  }
}