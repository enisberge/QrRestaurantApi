namespace QRRestaurantApp.Backend.DTOs.ProductDtos
{
    public class ResultProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
