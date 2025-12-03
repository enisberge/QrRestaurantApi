using QRRestaurantApp.Backend.DTOs.OptionDtos;
using QRRestaurantApp.Backend.DTOs.ProductDtos;
using QRRestaurantApp.Backend.Helpers;

namespace QRRestaurantApp.Backend.Services.OptionServices
{
    public interface IOptionGroupService
    {
        Task<ApiResponse<List<ResultOptionGroupDto>>> GetAllOptionGroupAsync();
        Task<ApiResponse<ResultOptionGroupDto>> CreateOptionGroupAsync(CreateOptionGroupDto createOptionGroupDto);
        Task<ApiResponse<string>> UpdateOptionGroupAsync(UpdateOptionGroupDto updateOptionGroupDto);
        Task<ApiResponse<string>> DeleteOptionGroupAsync(int id);
    }
}
