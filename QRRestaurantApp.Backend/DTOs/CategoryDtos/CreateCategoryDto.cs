namespace QRRestaurantApp.Backend.DTOs.CategoryDtos
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public bool IsActive { get; set; }
    }
}
