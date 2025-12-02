using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QRRestaurantApp.Backend.Context;
using QRRestaurantApp.Backend.DTOs.TableSessionDtos;
using QRRestaurantApp.Backend.Entities;
using QRRestaurantApp.Backend.Helpers;
using QRRestaurantApp.Backend.Services.JwtServices;

namespace QRRestaurantApp.Backend.Services.TableSessionsServices
{
    public class TableSessionService : ITableSessionService
    {
        private readonly SqlContext _context;
        private readonly IJwtService _jwtService;
        public TableSessionService(SqlContext context, IJwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        private readonly IMapper _mapper;
        public async Task<ApiResponse<ResultTableSessionLogDto>> CreateTableSessionLogAsync(CreateTableSessionLogDto createTableSessionLogDto)
        {
            //Masa var mı?
            var table = await _context.Tables.FirstOrDefaultAsync(t => t.Code == createTableSessionLogDto.Code);

            if (table == null)
            {
                return ApiResponse<ResultTableSessionLogDto>.FailResponse("Masa Bulunamadı.");
            }

            //Oturum süresi belirler

            TimeSpan lifeTime = TimeSpan.FromHours(5); //henüz sipariş yok kısa süre bakılacak

            //JWT Üret

            string token = _jwtService.GenerateCustomerToken(
                table.Id,
                table.Code,
                createTableSessionLogDto.DeviceId,
                lifeTime,
                hasOrder: false //ilk anda sipariş yok sadece giriş
                );
            var log = new TableSessionLog {
            TableId = table.Id,
            Code = table.Code,
            DeviceId = createTableSessionLogDto.DeviceId,
            SessionStart=DateTime.UtcNow,
            LastActivity=DateTime.UtcNow,
            SessionEnd=null, //oturum bitince güncellenecek
            HasOrder=false,
            };
            await _context.TableSessionLogs.AddAsync(log);
            await _context.SaveChangesAsync();
            //Frontend için DTO dönüşü

            var result = new ResultTableSessionLogDto
            {
                TableId = table.Id,
                TableName = table.Name,
                Code = table.Code,
                Token = token,
                DeviceId = createTableSessionLogDto.DeviceId,
            };
            return ApiResponse<ResultTableSessionLogDto>.SuccessResponse(result, "Oturum başlatıldı.");
        }
    }
}
