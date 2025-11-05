namespace QRRestaurantApp.Backend.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }

        //sipariş ile ilişkili olacak. böyle yapma sebebimiz bir siparişte birden fazla ürün olabilir. bu ürünlerin eğer varsa promosyonları da ayrı hesaplanmalı
        public int OrderId { get; set; }
        public Order Order { get; set; }

        //Ürün ilişkisi

        public int ProductId { get; set; }
        public Product Product { get; set; }

        //Miktar
        public int Quantity { get; set; }
        public Decimal UnitPrice { get; set; }

        // 🎁 Kampanya snapshot (sade versiyon)
        public int? PromotionId { get; set; }         // İstersen tut, raporlama kolay olur
        public string? PromotionName { get; set; }    // “%20 İndirim” veya “2 al 1 öde”
        public decimal DiscountAmount { get; set; }   // Bu satırda uygulanan indirim tutarı
       
        public decimal TotalPrice => UnitPrice * Quantity; // Satır toplamını hesaplayabiliriz

    }
}
