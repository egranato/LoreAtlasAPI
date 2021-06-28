using System.ComponentModel.DataAnnotations;

namespace LoreAtlas.API.DTO
{
  public class RegisterDto
  {
    [Required]
    public string DisplayName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*^[a-zA-Z0-9]).{4,8}$", ErrorMessage = "Password must be complex")]
    public string Password { get; set; }
    public string Username { get; set; }
  }
}