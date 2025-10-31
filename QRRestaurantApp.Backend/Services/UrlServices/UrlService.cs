namespace QRRestaurantApp.Backend.Services.UrlServices
{
    public class UrlService : IUrlService
    {
        private readonly IHttpContextAccessor _context;

        public UrlService(IHttpContextAccessor context)
        {
            _context = context;
        }

        public string GetBaseImageUrl()
        {
            var req = _context.HttpContext?.Request;
            return $"{req?.Scheme}://{req?.Host}/";
        }

        public string GetCategoryImageUrl()
        {
            return $"{GetBaseImageUrl()}uploads/categories/";
        }

        public string GetProductImageUrl()
        {
            return $"{GetBaseImageUrl()}uploads/products/";
        }

        public string GetPromotionImageUrl()
        {
            return $"{GetBaseImageUrl()}uploads/promotions/";
        }
    }
}
