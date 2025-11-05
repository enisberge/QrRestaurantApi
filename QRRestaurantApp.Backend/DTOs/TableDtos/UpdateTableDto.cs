namespace QRRestaurantApp.Backend.DTOs.TableDtos
{
    public class UpdateTableDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}