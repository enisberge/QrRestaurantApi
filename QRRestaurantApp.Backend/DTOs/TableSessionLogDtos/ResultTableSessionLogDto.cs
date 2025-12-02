namespace QRRestaurantApp.Backend.DTOs.TableSessionDtos
{
    public class ResultTableSessionLogDto
    {
        public int TableId { get; set; } //Masa Idsi
        public string TableName { get; set; } //Masa Adı (ör: "A12" veya "Salon 3")
        public string Code { get; set; } // Masa Kodu (ör: "A12")
        public string Token { get; set; } //JWT ile üretilen token
        public string DeviceId { get; set; } //Cihaz Idsi

    }
}
