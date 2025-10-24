using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QRRestaurantApp.Backend.Context;
using QRRestaurantApp.Backend.DTOs.CategoryDtos;
using QRRestaurantApp.Backend.DTOs.ProductDtos;
using QRRestaurantApp.Backend.Entities;
using QRRestaurantApp.Backend.Helpers;

namespace QRRestaurantApp.Backend.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly SqlContext _context;
        private readonly IMapper _mapper;

        public ProductService(SqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ResultProductDto>> CreateProductAsync(CreateProductDto createProductDto)
        {
            if (createProductDto == null)
            {
                return ApiResponse<ResultProductDto>.FailResponse("Geçersiz ürün verisi gönderildi.");
            }
            //Dosya İşlemleri
            string imageUrl = null;
            if (createProductDto.Image!=null&&createProductDto.Image.Length>0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "products");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                var fileName=Guid.NewGuid().ToString()+Path.GetExtension(createProductDto.Image.FileName);
                var filePath=Path.Combine(uploadsFolder, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await createProductDto.Image.CopyToAsync(stream);
                }
                imageUrl = fileName;
              
            }
            var product = _mapper.Map<Product>(createProductDto);
            product.ImageUrl = imageUrl;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            var result=_mapper.Map<ResultProductDto>(product);

            return ApiResponse<ResultProductDto>.SuccessResponse(result,"Ürün başarıyla oluşturuldu.");

        }

        public async Task<ApiResponse<string>> DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<List<ResultProductDto>>> GetAllProductAsync()
        {
           var products= await _context.Products.Where(p => p.IsActive).ToListAsync();
            var result=_mapper.Map<List<ResultProductDto>>(products);
            return ApiResponse<List<ResultProductDto>>.SuccessResponse(result);
        }
        
        public async Task<ApiResponse<string>> UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            throw new NotImplementedException();
        }
    }
}
