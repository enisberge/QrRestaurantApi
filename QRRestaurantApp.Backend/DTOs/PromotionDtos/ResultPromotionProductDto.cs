using Microsoft.EntityFrameworkCore;

namespace QRRestaurantApp.Backend.DTOs.PromotionDtos
{
    [Keyless] //bu sınıfın tablo değil sorgu 
    public class ResultPromotionProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public Decimal PromotionPrice { get; set; }
        public Decimal UnitPrice { get; set; }
        public string ProductImage { get; set; }
        public bool IsDishOfTheDay { get; set; }
        public int PromotionType { get; set; }
        public string PromotionImage { get; set; }
        public string PromotionName { get; set; }
        public string PromotionDescription { get; set; }
        public bool PromotionStatus { get; set; }
        public Decimal DiscountedPrice{ get; set; }
        public string DisplayText { get; set; }
    }
}
