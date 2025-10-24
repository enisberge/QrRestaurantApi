using QRRestaurantApp.Backend.DTOs.ProductDtos;
using QRRestaurantApp.Backend.Helpers;

namespace QRRestaurantApp.Backend.Services.ProductService
{
    public interface IProductService
    {
        Task<ApiResponse<List<ResultProductDto>>> GetAllProductAsync();
        Task<ApiResponse<ResultProductDto>> CreateProductAsync (CreateProductDto createProductDto);
        Task<ApiResponse<string>> UpdateProductAsync(UpdateProductDto updateProductDto);
        Task<ApiResponse<string>> DeleteProductAsync(int id);
    }
}
