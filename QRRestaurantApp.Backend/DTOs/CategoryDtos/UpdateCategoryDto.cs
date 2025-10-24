namespace QRRestaurantApp.Backend.DTOs.CategoryDtos
{
    public class UpdateCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdatedDate { get; set; }= DateTime.Now;
    }
}
