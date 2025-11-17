namespace QRRestaurantApp.Backend.DTOs.TableSessionDtos
{
    public class ResultTableSessionDto
    {
        public int TableId { get; set; } //Masa Idsi
        public string TableName { get; set; } //Masa Adı (ör: "A12" veya "Salon 3")
        public string Code { get; set; } // Masa Kodu (ör: "A12")
        public bool IsTableActive { get; set; } //Masanın aktiflik durumu
        public DateTime SessionStart { get; set; } //oturum başlama zamanı
        public DateTime SessionEnd { get; set; }
        public bool HasOrder { get; set; } //sipariş var mı yok mu
        public DateTime LastActivity { get; set; }

    }
}
