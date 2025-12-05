namespace QRRestaurantApp.Backend.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category{ get; set; }
        public bool IsActive { get; set; }
        public bool? isDishOfTheDay { get; set; }//günü yemeği mi
        public DateTime CreatedDate { get; set; }=DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public List<Promotion> Promotions { get; set; }

        public List<OrderItem> OrderItems { get; set; }
        public List<ProductOptionGroup> ProductOptionGroups { get; set; }
    }
}
