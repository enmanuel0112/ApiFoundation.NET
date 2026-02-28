using ApiFoundation.NET.Dtos;
using ApiFoundation.NET.Models;
using ApiFoundation.NET.Services;
using System.Security.Cryptography.X509Certificates;

namespace ApiFoundation.NET.InMemory
{
    public class InMemoryProductService : IProductService
    {
        private static readonly List<Product> _products = new List<Product>();

        public IEnumerable<ProductResponseDto> GetAll()
           => _products.Select(ToResponse);

        public ProductResponseDto? GetById(Guid id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            return product is null ? null : ToResponse(product);
        }

        public ProductResponseDto Create(CreateProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name.Trim(),
                Price = dto.Price,
                Stock = dto.Stock,
                CreatedAt = DateTime.UtcNow
            };
            _products.Add(product);
            return ToResponse(product);
        }
        public bool Update(Guid id, UpdateProductDto dto)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product is null) return false;

            product.Name = dto.Name.Trim();
            product.Price = dto.Price;
            product.Stock = dto.Stock;

            return true;
        }
        public bool Delete(Guid id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product is null) return false;

            _products.Remove(product);
            return true;
        }

        private static ProductResponseDto ToResponse(Product p)
        => new()
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Stock = p.Stock,
            CreatedAt = p.CreatedAt
        };
    }
}
