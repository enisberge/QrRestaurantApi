using QRRestaurantApp.Backend.DTOs.TableSessionDtos;
using QRRestaurantApp.Backend.Helpers;

namespace QRRestaurantApp.Backend.Services.TableSessionsServices
{
    public interface ITableSessionService
    {
        Task<ApiResponse<ResultTableSessionLogDto>> CreateTableSessionLogAsync(CreateTableSessionLogDto createTableSessionDto);
    }
}
