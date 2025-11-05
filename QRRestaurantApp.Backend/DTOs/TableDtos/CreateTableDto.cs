namespace QRRestaurantApp.Backend.DTOs.TableDtos
{
    public class CreateTableDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}