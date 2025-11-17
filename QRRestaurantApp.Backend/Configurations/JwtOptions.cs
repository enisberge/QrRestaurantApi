namespace QRRestaurantApp.Backend.Configurations
{
    public class JwtOptions
    {
        //Gizli anahtar key
        public string Key { get; set; } = string.Empty;

        //Tokenı oluşturan kim
        public string Issuer { get; set; } = string.Empty;

        //Müşteri tarafı (QR uygulaması)
        public string CustomerAudience { get; set; } = string.Empty;

        //Admin kasa tarafı (panel)
        public string AdminAudience { get; set; } = string.Empty;

    }
}
