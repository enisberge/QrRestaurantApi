namespace QRRestaurantApp.Backend.Entities
{
    public class Order
    {
        public int Id { get; set; }
        // 🔗 Masa ilişkisi
        public int TableId { get; set; }
        public Table Table { get; set; }
        // 🕓 Zaman bilgisi
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }

        //İlişkiler
        public List<OrderItem> OrderItems { get; set; }
    }
}
