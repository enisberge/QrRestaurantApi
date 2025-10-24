using QRRestaurantApp.Backend.Enums;

namespace QRRestaurantApp.Backend.DTOs.PromotionDtos
{
    public class CreatePromotionDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile? Image { get; set; }
        public PromotionType PromotionType { get; set; }
        public decimal? Value { get; set; }
        public int? X { get; set; } //2 AL 1 ÖDE X=2
        public int? Y { get; set; }//2 AL 1 ÖDE Y=1
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int ProductId { get; set; }
    }
}
