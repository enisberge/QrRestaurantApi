using QRRestaurantApp.Backend.Enums;

namespace QRRestaurantApp.Backend.Entities
{
    public class OptionGroup
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!; // 🔥 Örn: "Porsiyon", "Ekstra", "Çıkarılacaklar"
        public string Description { get; set; } //birden fazla sos vb eklenirse admin tarafında karışmaması için
        public VariationType VariationType { get; set; }
        public bool IsRequired { get; set; }
        public int MinSelect { get; set; }
        public int MaxSelect { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public List<OptionValue> OptionValues { get; set; }
        public List<ProductOptionGroup> ProductOptionGroups { get; set; }
    }
}
