namespace QRRestaurantApp.Backend.DTOs.OptionValueDtos
{
    public class UpdateOptionValueDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? PriceDiff { get; set; }
        public int DisplayOrder { get; set; }
        public int OptionGroudId { get; set; }
    }
}
