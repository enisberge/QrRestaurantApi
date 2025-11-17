namespace QRRestaurantApp.Backend.Entities
{
    public class Table
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set;}

        public List<TableSessionLog> TableSessionLogs { get; set; } //1 masaya ait birden fazla oturum bilgisi olabilir
        public List<Order> Orders { get; set; } //1 masaya ait birden fazla sipariş bilgisi olabilir
    }
}
