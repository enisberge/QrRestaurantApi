using QRRestaurantApp.Backend.Enums;

namespace QRRestaurantApp.Backend.Entities
{
    public class Promotion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public  string? ImageUrl { get; set; }
        public PromotionType PromotionType { get; set; } // % indirim, 2 al 1 öde, sabit indirim
        public decimal? Value { get; set; } //% oran veya sabit fiyat
        public int? X { get; set; } //2 AL 1 ÖDE X=2
        public int? Y { get; set; }//2 AL 1 ÖDE Y=1
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }=DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public DateTime StartDate { get; set; } //kampanyanın başladığı tarih - bugünden eski olamaz - StartDate < EndDate
        public DateTime? EndDate { get; set; } //boş bırakılırsa süresiz kampanya
        public int ProductId { get; set; }
        public Product Product { get; set; }


    }
}
