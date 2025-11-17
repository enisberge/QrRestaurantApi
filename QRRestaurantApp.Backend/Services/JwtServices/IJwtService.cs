namespace QRRestaurantApp.Backend.Services.JwtServices
{
    public interface IJwtService
    {
        string GenerateCustomerToken(int tableId, string code, string deviceId, TimeSpan lifetime, bool hasOrder);
        string GenerateAdminToken(string username, string role, TimeSpan lifetime);
    }
}
