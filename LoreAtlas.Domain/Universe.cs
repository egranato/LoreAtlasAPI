using System;
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

    [ForeignKey("User")]
    public string OwnerId { get; set; }
    public User Owner { get; set; }
  }
}