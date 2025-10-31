using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QRRestaurantApp.Backend.Context;
using QRRestaurantApp.Backend.DTOs.CategoryDtos;
using QRRestaurantApp.Backend.DTOs.PromotionDtos;
using QRRestaurantApp.Backend.Entities;
using QRRestaurantApp.Backend.Helpers;
using QRRestaurantApp.Backend.Services.UrlServices;

namespace QRRestaurantApp.Backend.Services.PromotionServices
{
    public class PromotionService : IPromotionService
    {
        private readonly SqlContext _context;

        private readonly IMapper _mapper;
        private readonly IUrlService _urlService;
        public PromotionService(SqlContext context, IMapper mapper, IUrlService urlService)
        {
            _context = context;
            _mapper = mapper;
            _urlService = urlService;
        }

        public async Task<ApiResponse<ResultPromotionDto>> CreatePromotionAsync(CreatePromotionDto createPromotionDto)
        {
            if (createPromotionDto == null)
            {
                return ApiResponse<ResultPromotionDto>.FailResponse("Geçersiz kampanya verisi gönderildi.");
            }
            //Tarih kontrolleri
            if (createPromotionDto.StartDate < DateTime.Now)
            {
                return ApiResponse<ResultPromotionDto>.FailResponse("Kampanya tarihi şu andan önce olamaz.");
            }
            if (createPromotionDto.EndDate.HasValue && createPromotionDto.EndDate <= createPromotionDto.StartDate)
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
                imageUrl = fileName;

            }
            var promotion = _mapper.Map<Promotion>(createPromotionDto);
            promotion.ImageUrl = imageUrl;
            _context.Promotions.Add(promotion);
            await _context.SaveChangesAsync();

            // 🔸 Map geri dönüş DTO'suna (Promotion → ResultPromotionDto)
            var result = _mapper.Map<ResultPromotionDto>(promotion);

            return ApiResponse<ResultPromotionDto>.SuccessResponse(result, "Kampanya başarıyla oluşturuldu.");
        }


        public async Task<ApiResponse<List<ResultPromotionDto>>> GetAllPromotionAsync()
        {
            var basePath = _urlService.GetPromotionImageUrl();
            var promotions = await _context.Promotions.Where(p => p.IsActive).ToListAsync();
            var result = _mapper.Map<List<ResultPromotionDto>>(promotions);
            foreach (var promotion in result)
            {
                // Eğer ImageUrl boşsa veya null'sa, olduğu gibi bırak
                if (!string.IsNullOrEmpty(promotion.ImageUrl))
                {
                    promotion.ImageUrl = $"{basePath}{promotion.ImageUrl}";
                }

            }
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

        public async Task<ApiResponse<List<ResultPromotionProductDto>>> GetPromotionProductsAsync()
        {
            try
            {
                var sql = @"
                  
   
   SELECT 
    p.Id,
    p.Name AS ProductName,
	CASE
		WHEN pr.PromotionType=2 THEN p.Price * pr.X
	ELSE p.Price
	END AS PromotionPrice, --yalnızca X AL Y öde için toplam fiyatı gösteriyoruz 
	p.price UnitPrice,
	p.ImageUrl ProductImage,
	ISNULL(p.IsDishOfTheDay,0) IsDishOfTheDay,
    ISNULL(pr.PromotionType, 0) AS PromotionType,
    ISNULL(pr.ImageUrl, p.ImageUrl) AS PromotionImage, -- kampanya resmi yoksa ürün resmi
    ISNULL(pr.Name, '') AS PromotionName,
	ISNULL(pr.Description, p.Description) AS PromotionDescription,
	ISNULL(pr.IsActive,0) AS PromotionStatus,
	
    -- ✅ İndirimli fiyat hesaplama
    CASE 
        WHEN pr.PromotionType = 1 THEN p.Price * (1 - pr.Value / 100.0)               -- % indirim
        WHEN pr.PromotionType = 2 AND pr.X > 0 THEN (p.Price * pr.Y)  -- x al y öde
        WHEN pr.PromotionType = 3 THEN p.Price - pr.Value                             -- sabit TL indirim
        ELSE p.Price                                                                  -- kampanya yoksa normal fiyat
    END AS DiscountedPrice,
    CASE 
        WHEN pr.PromotionType = 1 THEN CONCAT('%', FORMAT(pr.Value, '0.##'), ' indirim')
        WHEN pr.PromotionType = 2 THEN CONCAT(pr.X, ' alana ', pr.Y, ' bedava ')
        WHEN pr.PromotionType = 3 THEN CONCAT(FORMAT(pr.Value, '0.##'), ' TL indirim')
        WHEN ISNULL(p.IsDishOfTheDay, 0) = 1 THEN 'Günün Yemeği'
        ELSE 'Kampanya Yok'
    END AS DisplayText
FROM Products p
LEFT JOIN Promotions pr 
    ON p.Id = pr.ProductId
    AND ISNULL(pr.IsActive, 0) != 0 
    AND (pr.EndDate IS NULL OR pr.EndDate > GETDATE())  -- ✅ kampanya bitmemişse
WHERE 
    (ISNULL(p.IsActive, 0) != 0) 
    AND (ISNULL(p.IsDishOfTheDay, 0) != 0 OR pr.Id IS NOT NULL);
        ";
                var data = await _context.Database.SqlQueryRaw<ResultPromotionProductDto>(sql).ToListAsync();
                var baseImageUrl = _urlService.GetBaseImageUrl();
                foreach (var item in data)
                {
                    if (!string.IsNullOrEmpty(item.ProductImage))
                        item.ProductImage = $"{baseImageUrl}uploads/products/{item.ProductImage}";

                    if (!string.IsNullOrEmpty(item.PromotionImage))
                        item.PromotionImage = $"{baseImageUrl}uploads/promotions/{item.PromotionImage}";
                }
                return ApiResponse<List<ResultPromotionProductDto>>.SuccessResponse(data);
            }
            catch (Exception ex)
            {
                return ApiResponse<List<ResultPromotionProductDto>>.FailResponse($"Veri çekme hatası: {ex.Message}");
            }
        }
    }

}
