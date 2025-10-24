using QRRestaurantApp.Backend.Enums;

namespace QRRestaurantApp.Backend.DTOs.PromotionDtos
{
    public class ResultPromotionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public PromotionType PromotionType { get; set; }
        public decimal? Value { get; set; }
        public int? X { get; set; }
        public int? Y { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; } // direkt ürün adını da dönebilirsin
    }
}
