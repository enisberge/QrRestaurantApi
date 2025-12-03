namespace QRRestaurantApp.Backend.Entities
{
    public class OptionValue
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!; //"1,5 porsiyon", "Extra peynir", "Soğan çıkar"
        public decimal? PriceDiff { get; set; } //-- +5 TL, 0 TL
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public int OptionGroudId { get; set; }
        public OptionGroup OptionGroup { get; set; }
    }
}
