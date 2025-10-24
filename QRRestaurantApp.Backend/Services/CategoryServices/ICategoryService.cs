using QRRestaurantApp.Backend.DTOs.CategoryDtos;
using QRRestaurantApp.Backend.Helpers;

namespace QRRestaurantApp.Backend.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<ApiResponse<List<ResultCategoryDto>>> GetAllCategoryAsync();
        Task<ApiResponse<ResultCategoryDto>> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task<ApiResponse<string>> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task<ApiResponse<string>> DeleteCategoryAsync(int id);
    }
}
