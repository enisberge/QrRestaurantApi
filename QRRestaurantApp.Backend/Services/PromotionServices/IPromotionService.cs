using QRRestaurantApp.Backend.DTOs.PromotionDtos;
using QRRestaurantApp.Backend.Helpers;

namespace QRRestaurantApp.Backend.Services.PromotionServices
{
    public interface IPromotionService
    {
        Task<ApiResponse<List<ResultPromotionDto>>> GetAllPromotionAsync();
        Task<ApiResponse<List<ResultPromotionProductDto>>> GetPromotionProductsAsync();

        Task<ApiResponse<ResultPromotionDto>> CreatePromotionAsync (CreatePromotionDto createPromotionDto);
        Task<ApiResponse<string>> UpdatePromotionAsync(UpdatePromotionDto updatePromotionDto);
        Task<ApiResponse<string>> DeletePromotionAsync(int id);
    }
}
