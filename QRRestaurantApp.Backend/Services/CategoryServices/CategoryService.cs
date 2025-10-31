using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QRRestaurantApp.Backend.Context;
using QRRestaurantApp.Backend.DTOs.CategoryDtos;
using QRRestaurantApp.Backend.Entities;
using QRRestaurantApp.Backend.Helpers;
using QRRestaurantApp.Backend.Services.UrlServices;

namespace QRRestaurantApp.Backend.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly SqlContext _context;
        private readonly IMapper _mapper;
        private readonly IUrlService _urlService;   
        public CategoryService(SqlContext context, IMapper mapper,IUrlService urlService)
        {
            _context = context;
            _mapper = mapper;
            _urlService = urlService;
        }

        public async Task<ApiResponse<ResultCategoryDto>> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            if (createCategoryDto == null)
            {
                return ApiResponse<ResultCategoryDto>.FailResponse("Geçersiz kategori verisi gönderildi.");
            }

            // 🔸 Dosya işlemleri
            string imageUrl = null;

            if (createCategoryDto.Image != null && createCategoryDto.Image.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "categories");

                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(createCategoryDto.Image.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await createCategoryDto.Image.CopyToAsync(stream);
                }

                // sadece dosya adını kaydet
                imageUrl = fileName;
            }

            // 🔸 DTO → Entity dönüşümü
            var category = _mapper.Map<Category>(createCategoryDto);
            category.ImageUrl = imageUrl;

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            // 🔸 Entity → DTO dönüşümü (frontend’e göstermek için)
            var result = _mapper.Map<ResultCategoryDto>(category);

            return ApiResponse<ResultCategoryDto>.SuccessResponse(result, "Kategori başarıyla oluşturuldu.");
        }

        public async Task<ApiResponse<string>> DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<List<ResultCategoryDto>>> GetAllCategoryAsync()
        {
            var basePath = _urlService.GetCategoryImageUrl();
            var categories = await _context.Categories.Where(c => c.IsActive).ToListAsync();
            var result = _mapper.Map<List<ResultCategoryDto>>(categories);

            foreach (var category in result)
            {
                // Eğer ImageUrl boşsa veya null'sa, olduğu gibi bırak
                if (!string.IsNullOrEmpty(category.ImageUrl))
                {
                    category.ImageUrl = $"{basePath}{category.ImageUrl}";
                }

            }

            return ApiResponse<List<ResultCategoryDto>>.SuccessResponse(result);
      
        }

        public async Task<ApiResponse<string>> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
