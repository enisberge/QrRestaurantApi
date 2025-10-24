namespace QRRestaurantApp.Backend.DTOs.ProductDtos
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public IFormFile Image { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
    }
}
