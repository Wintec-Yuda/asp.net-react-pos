using System.ComponentModel.DataAnnotations;

namespace PointOfSale.DTO.Request;

public class RegisterRequestDto
{
  [Required]
  [StringLength(50, MinimumLength = 5)]
  public string? Name { get; set; }
  [Required]
  [EmailAddress]
  public string? Email { get; set; }
  [Required]
  [StringLength(50, MinimumLength = 3)]
  public string? Password { get; set; }
}

