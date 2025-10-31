namespace QRRestaurantApp.Backend.Services.UrlServices
{
    public interface IUrlService
    {
        string GetBaseImageUrl();
        string GetCategoryImageUrl();
        string GetProductImageUrl();
        string GetPromotionImageUrl();
    }
}
