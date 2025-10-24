namespace QRRestaurantApp.Backend.DTOs.ProductDtos
{
    public class UpdateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public DateTime UpdatedDate { get; set; }=DateTime.Now;
    }
}
