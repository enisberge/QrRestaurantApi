namespace QRRestaurantApp.Backend.DTOs.TableSessionDtos
{
    public class CreateTableSessionLogDto
    {
        public string Code { get; set; }= null!;     // QR koddan gelen masa kodu
        public string DeviceId { get; set; } = null!; // Cihaz kimliği
    }
}
