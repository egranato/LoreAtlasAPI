using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace LoreAtlas.Domain
{
  public class User : IdentityUser
  {
    public string DisplayName { get; set; }

    [InverseProperty("Owner")]
    public ICollection<Universe> Universes { get; set; }
  }
}