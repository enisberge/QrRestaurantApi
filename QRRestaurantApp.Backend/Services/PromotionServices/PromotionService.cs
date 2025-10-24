using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QRRestaurantApp.Backend.Context;
using QRRestaurantApp.Backend.DTOs.CategoryDtos;
using QRRestaurantApp.Backend.DTOs.PromotionDtos;
using QRRestaurantApp.Backend.Entities;
using QRRestaurantApp.Backend.Helpers;

namespace QRRestaurantApp.Backend.Services.PromotionServices
{
    public class PromotionService : IPromotionService
    {
        private readonly SqlContext _context;

        private readonly IMapper _mapper;
        public PromotionService(SqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ResultPromotionDto>> CreatePromotionAsync(CreatePromotionDto createPromotionDto)
        {
            if (createPromotionDto == null)
            {
                return ApiResponse<ResultPromotionDto>.FailResponse("Geçersiz kampanya verisi gönderildi.");
            }
            //Tarih kontrolleri
            if (createPromotionDto.StartDate<DateTime.Now)
            {
                return ApiResponse<ResultPromotionDto>.FailResponse("Kampanya tarihi şu andan önce olamaz.");
            }
            if (createPromotionDto.EndDate.HasValue&&createPromotionDto.EndDate<=createPromotionDto.StartDate)
            {
                return ApiResponse<ResultPromotionDto>.FailResponse("Bitiş tarihi başlangıç tarihinden sonra olmalıdır.");
            }
            if (createPromotionDto.EndDate.HasValue && createPromotionDto.EndDate < DateTime.Now)
            {
                return ApiResponse<ResultPromotionDto>.FailResponse("Bitiş tarihi geçmiş bir tarih olamaz.");
            }
            //Dosya İşlemleri
            string imageUrl = null;
            if (createPromotionDto.Image != null && createPromotionDto.Image.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "promotions");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(createPromotionDto.Image.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await createPromotionDto.Image.CopyToAsync(stream);
                }
                imageUrl = filePath;

            }
            var promotion=_mapper.Map<Promotion>(createPromotionDto);
            promotion.ImageUrl = imageUrl;
            _context.Promotions.Add(promotion);
            await _context.SaveChangesAsync();

            // 🔸 Map geri dönüş DTO'suna (Promotion → ResultPromotionDto)
            var result = _mapper.Map<ResultPromotionDto>(promotion);

            return ApiResponse<ResultPromotionDto>.SuccessResponse(result, "Kampanya başarıyla oluşturuldu.");
        }

      
        public async Task<ApiResponse<List<ResultPromotionDto>>> GetAllPromotionAsync()
        {
            var promotions = await _context.Promotions.Where(p => p.IsActive).ToListAsync();
            var result = _mapper.Map<List<ResultPromotionDto>>(promotions);
            return ApiResponse<List<ResultPromotionDto>>.SuccessResponse(result);
        }

        public Task<ApiResponse<string>> UpdatePromotionAsync(UpdatePromotionDto updatePromotionDto)
        {
            throw new NotImplementedException();
        }

       public Task<ApiResponse<string>> DeletePromotionAsync(int id)
        {
            throw new NotImplementedException();
        }
    }

}
