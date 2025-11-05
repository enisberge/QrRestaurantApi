namespace QRRestaurantApp.Backend.Entities
{
    public class TableSession
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }

        public string DeviceId { get; set; } = string.Empty;  // 🔹 her cihaz için benzersiz
        public string SessionToken { get; set; } = Guid.NewGuid().ToString();

        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ClosedAt { get; set; }

        // 🔗 Bu session’a bağlı siparişler
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }

}
