using System.ComponentModel.DataAnnotations;

namespace PointOfSale.DTO.Request;

public class ProductRequestDto
{
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string? Name { get; set; }
    [Required]
    [Range(0, int.MaxValue)]
    public int Price { get; set; }
    [Required]
    [Range(0, int.MaxValue)]
    public int Stock { get; set; }
}
