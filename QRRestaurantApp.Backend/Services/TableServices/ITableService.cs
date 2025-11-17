using QRRestaurantApp.Backend.DTOs.CategoryDtos;
using QRRestaurantApp.Backend.DTOs.TableDtos;
using QRRestaurantApp.Backend.Helpers;

namespace QRRestaurantApp.Backend.Services.TableServices
{
    public interface ITableService
    {

        Task<ApiResponse<List<ResultTableDto>>> GetAllTableAsync();
        Task<ApiResponse<ResultTableDto>> GetByCodeAsync(string code);
        Task<ApiResponse<ResultTableDto>> CreateTableAsync(CreateTableDto createTableDto);
        Task<ApiResponse<string>> UpdateTableAsync(UpdateTableDto updateTableDto);
        Task<ApiResponse<string>> DeleteTableAsync(int id);
    }
}
