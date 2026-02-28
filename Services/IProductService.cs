using ApiFoundation.NET.Dtos;
namespace ApiFoundation.NET.Services
{
    public interface IProductService
    {
        IEnumerable<ProductResponseDto> GetAll();

        ProductResponseDto GetById(Guid id);
        ProductResponseDto Create(CreateProductDto dto);

        bool Update(Guid id, UpdateProductDto dto);

        bool Delete(Guid id);


    }
}
