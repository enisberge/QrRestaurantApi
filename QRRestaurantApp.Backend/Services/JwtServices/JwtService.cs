
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using QRRestaurantApp.Backend.Configurations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QRRestaurantApp.Backend.Services.JwtServices
{
    public class JwtService : IJwtService
    {
        private readonly JwtOptions _options;
        private readonly byte[] _keyBytes;

        public JwtService(IOptions<JwtOptions> options)
        {
            _options = options.Value;
            _keyBytes = Encoding.UTF8.GetBytes(_options.Key);

        }
        //Admin / Kasa Token'ı
        public string GenerateAdminToken(string username, string role, TimeSpan lifetime)
        {
            var claims = new List<Claim> {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role),// örnek: "admin", "cashier"
            
            };

            return GenerateToken(claims, _options.AdminAudience, lifetime);
        }

        // QR müşteri token’ı
        // Bu tokenla ilgili masaya ve cihaza ait kullanıcı bilgileri belirli süreliğine tutuluyor.
        // Eğer sipariş verirse bu süre biraz daha uzuyor
        public string GenerateCustomerToken(int tableId, string code, string deviceId, TimeSpan lifetime, bool hasOrder)
        {
            var claims = new List<Claim>
            {
                new Claim("tid",tableId.ToString()),
                new Claim("code", code),
                new Claim("did", deviceId),
                new Claim("hasOrder",hasOrder?"1":"0"), //sipariş verdi mi 
                new Claim(ClaimTypes.Role,"customer")

            };
            return GenerateToken(claims, _options.CustomerAudience, lifetime);
        }

        // Ortam token üretim mantığı

        private string GenerateToken(List<Claim> claims, string audience, TimeSpan lifetime)
        {
            var credentials = new SigningCredentials
                (
                new SymmetricSecurityKey(_keyBytes),
                SecurityAlgorithms.HmacSha256
                );


            var token = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.Add(lifetime),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }


    }
}
