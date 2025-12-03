using QRRestaurantApp.Backend.DTOs.OptionValueDtos;
using QRRestaurantApp.Backend.Helpers;

namespace QRRestaurantApp.Backend.Services.OptionValueServices
{
    public interface IOptionValueService
    {
        Task<ApiResponse<List<ResultOptionValueDto>>> GetAllOptionValueAsync();
        Task<ApiResponse<ResultOptionValueDto>> CreateOptionValueAsync(CreateOptionValueDto createOptionValueDto);
        Task<ApiResponse<string>> UpdateOptionValueAsync(UpdateOptionValueDto updateOptionValueDto);
        Task<ApiResponse<string>> DeleteOptionGroupAsync(int id);
    }
}
