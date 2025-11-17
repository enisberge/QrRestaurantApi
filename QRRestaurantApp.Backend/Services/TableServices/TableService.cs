using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QRRestaurantApp.Backend.Context;
using QRRestaurantApp.Backend.DTOs.CategoryDtos;
using QRRestaurantApp.Backend.DTOs.TableDtos;
using QRRestaurantApp.Backend.Entities;
using QRRestaurantApp.Backend.Helpers;

namespace QRRestaurantApp.Backend.Services.TableServices
{
    public class TableService : ITableService
    {
        private readonly SqlContext _context;
        private readonly IMapper _mapper;

        public TableService(IMapper mapper, SqlContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ApiResponse<ResultTableDto>> CreateTableAsync(CreateTableDto createTableDto)
        {
            //Aynı masa kodu mevcut mu kontrol et
            var exist=await _context.Tables.AnyAsync(t=>t.Code == createTableDto.Code);

            if (createTableDto == null)
                return ApiResponse<ResultTableDto>.FailResponse("Geçersiz masa verisi gönderildi.");
            
            if (exist)
                return ApiResponse<ResultTableDto>.FailResponse("Bu kodla kayıtlı bir masa zaten var.");

            // Mapper ile Table nesnesine dönüştür
            var table = _mapper.Map<Table>(createTableDto);

            // Veritabanına kaydet
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();

            // Kaydedilen veriyi DTO'ya dönüştür
            var result = _mapper.Map<ResultTableDto>(table);

            return ApiResponse<ResultTableDto>.SuccessResponse(result, "Masa başarıyla eklendi.");

        }

        public Task<ApiResponse<string>> DeleteTableAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<List<ResultTableDto>>> GetAllTableAsync()
        {
            // 1️⃣ Aktif masaları çek
            var tables = await _context.Tables
                .Where(c => c.IsActive)
                .ToListAsync();

            // 2️⃣ Table -> ResultTableDto listesine map et
            var result = _mapper.Map<List<ResultTableDto>>(tables);

            return ApiResponse<List<ResultTableDto>>.SuccessResponse(result);
        }

        public async Task<ApiResponse<ResultTableDto>> GetByCodeAsync(string code)
        {
            var table= await _context.Tables.FirstOrDefaultAsync(c => c.Code == code);
            if (table == null)
                return ApiResponse<ResultTableDto>.FailResponse("Masa Bulunamadı veya geçersiz QR kodu.");

            var result=_mapper.Map<ResultTableDto>(table);
            return ApiResponse<ResultTableDto>.SuccessResponse(result);
        }

        public Task<ApiResponse<string>> UpdateTableAsync(UpdateTableDto updateTableDto)
        {
            throw new NotImplementedException();
        }
    }
}
