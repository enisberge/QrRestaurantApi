using QRRestaurantApp.Backend.Context;
using QRRestaurantApp.Backend.DTOs.ProductOptionGroupDtos;
using QRRestaurantApp.Backend.Helpers;
using QRRestaurantApp.Backend.Services.ProductProductOptionGroupServices;

namespace QRRestaurantApp.Backend.Services.ProductOptionGroupServices
{
    public class ProductOptionGroupService : IProductOptionGroupService
    {
        private readonly SqlContext _sqlContext;

        public ProductOptionGroupService(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task<ApiResponse<ResultProductOptionGroupDto>> CreateProductOptionGroupAsync(CreateProductOptionGroupDto createProductOptionGroupDto)
        {
            await _sqlContext

        }

        public Task<ApiResponse<List<ResultProductOptionGroupDto>>> GetAllProductOptionGroupAsync()
        {
            throw new NotImplementedException();
        }
    }
}
