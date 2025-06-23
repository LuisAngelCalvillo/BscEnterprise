using Shared.DTOs;

namespace Logic.Interfaces
{
    public interface IProductService
    {
        Task<ResponseDataDto<List<ProductDto>>> GetAllProductsAsync();
        Task<ResponseDto> InsertProductAsync(ProductDto product);
    }
}
