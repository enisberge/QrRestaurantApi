using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QRRestaurantApp.Backend.Services.JwtServices;

namespace QRRestaurantApp.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestTokenController : ControllerBase
    {
        private readonly IJwtService _jwtService;

        public TestTokenController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        //  Müşteri token üret
        [HttpGet("customer")]
        public IActionResult GetCustomerToken()
        {
            var token = _jwtService.GenerateCustomerToken(
                tableId: 12,
                code: "A12",
                deviceId: "DEVICE123",
                lifetime: TimeSpan.FromHours(2),
                hasOrder: false
            );
            return Ok(new { token });
        }

        // Admin token üret
        [HttpGet("admin")]
        public IActionResult GetAdminToken()
        {
            var token = _jwtService.GenerateAdminToken(
                username: "adminUser",
                role: "admin",
                lifetime: TimeSpan.FromHours(8)
            );
            return Ok(new { token });
        }
    }
}

