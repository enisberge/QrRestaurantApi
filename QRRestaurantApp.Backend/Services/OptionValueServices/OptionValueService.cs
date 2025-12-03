using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QRRestaurantApp.Backend.Context;
using QRRestaurantApp.Backend.DTOs.OptionValueDtos;
using QRRestaurantApp.Backend.Entities;
using QRRestaurantApp.Backend.Helpers;

namespace QRRestaurantApp.Backend.Services.OptionValueServices
{
    public class OptionValueService : IOptionValueService
    {
        private readonly SqlContext _context;

        private readonly IMapper _mapper;
        public OptionValueService(SqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ResultOptionValueDto>> CreateOptionValueAsync(CreateOptionValueDto createOptionValueDto)
        {
            if (createOptionValueDto == null)
            {
                return ApiResponse<ResultOptionValueDto>.FailResponse("Geçersiz ürün seçenek verisi.");
            }
            var optionValue = _mapper.Map<OptionValue>(createOptionValueDto);
            await _context.OptionValues.AddAsync(optionValue);
            await _context.SaveChangesAsync();
            return ApiResponse<ResultOptionValueDto>.SuccessResponse(_mapper.Map<ResultOptionValueDto>(optionValue), "Ürün seçeneği başarıyla oluşturuldu.");

        }

        public Task<ApiResponse<string>> DeleteOptionGroupAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<List<ResultOptionValueDto>>> GetAllOptionValueAsync()
        {
            var optionValues = await _context.OptionValues.Where(ov=>ov.IsActive).ToListAsync();
            var result= _mapper.Map<List<ResultOptionValueDto>>(optionValues);

            return ApiResponse<List<ResultOptionValueDto>>.SuccessResponse(result);
        }

        public Task<ApiResponse<string>> UpdateOptionValueAsync(UpdateOptionValueDto updateOptionValueDto)
        {
            throw new NotImplementedException();
        }
    }
}
