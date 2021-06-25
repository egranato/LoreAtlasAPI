using System;
using System.ComponentModel.DataAnnotations;

namespace LoreAtlas.Domain
{
  public class BaseEntity
  {
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
  }
}