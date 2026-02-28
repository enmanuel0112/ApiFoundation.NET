using System.ComponentModel.DataAnnotations;

namespace ApiFoundation.NET.Dtos
{
    public class UpdateProductDto
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; } = string.Empty;

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Stock { get; set; }
    }
}
