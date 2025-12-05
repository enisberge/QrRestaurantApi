using QRRestaurantApp.Backend.DTOs.ProductOptionGroupDtos;
using QRRestaurantApp.Backend.Helpers;

namespace QRRestaurantApp.Backend.Services.ProductProductOptionGroupServices
{
    public interface IProductOptionGroupService
    {
        Task<ApiResponse<ResultProductOptionGroupDto>> CreateProductOptionGroupAsync(CreateProductOptionGroupDto createProductOptionGroupDto);
        Task<ApiResponse<List<ResultProductOptionGroupDto>>> GetAllProductOptionGroupAsync();
    }
}
