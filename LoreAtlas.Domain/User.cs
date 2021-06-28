using Microsoft.AspNetCore.Identity;

namespace LoreAtlas.Domain
{
  public class User : IdentityUser
  {
    public string DisplayName { get; set; }
  }
}