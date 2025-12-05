namespace QRRestaurantApp.Backend.Entities
{
    public class ProductOptionGroup
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int OptionGroupId { get; set; }
        public OptionGroup OptionGroup { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
