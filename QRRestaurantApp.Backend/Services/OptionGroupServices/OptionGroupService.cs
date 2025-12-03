using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QRRestaurantApp.Backend.Context;
using QRRestaurantApp.Backend.DTOs.OptionDtos;
using QRRestaurantApp.Backend.Entities;
using QRRestaurantApp.Backend.Helpers;

namespace QRRestaurantApp.Backend.Services.OptionServices
{
    public class OptionGroupService : IOptionGroupService
    {
        private readonly SqlContext _context;
        private readonly IMapper _mapper;
        public OptionGroupService(SqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ResultOptionGroupDto>> CreateOptionGroupAsync(CreateOptionGroupDto createOptionGroupDto)
        {
            if (createOptionGroupDto == null)
            {
                return ApiResponse<ResultOptionGroupDto>.FailResponse("Geçersiz ürün seçenek grubu.");
            }

            var optionGroup = _mapper.Map<OptionGroup>(createOptionGroupDto);
            await _context.OptionGroups.AddAsync(optionGroup);
            await _context.SaveChangesAsync();

            var result= _mapper.Map<ResultOptionGroupDto>(optionGroup);
            return ApiResponse<ResultOptionGroupDto>.SuccessResponse(result, "Seçenek grubu başarıyla oluşturuldu.");
        }

        public Task<ApiResponse<string>> DeleteOptionGroupAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<List<ResultOptionGroupDto>>> GetAllOptionGroupAsync()
        {
            var optionGroups = await _context.OptionGroups.Where(og=> og.IsActive).ToListAsync();
            var result = _mapper.Map<List<ResultOptionGroupDto>>(optionGroups);

            return ApiResponse<List<ResultOptionGroupDto>>.SuccessResponse(result);
        }

        public Task<ApiResponse<string>> UpdateOptionGroupAsync(UpdateOptionGroupDto updateOptionGroupDto)
        {
            throw new NotImplementedException();
        }
    }
}
