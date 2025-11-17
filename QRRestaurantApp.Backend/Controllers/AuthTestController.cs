using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QRRestaurantApp.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthTestController : ControllerBase
    {
        [HttpGet("customer")]
        [Authorize(Roles = "customer")]
        public IActionResult CustomerTest()
        {
            return Ok(new {message="Customer token geçerli, erişim başarılı."});
        }

        [HttpGet("admin")]
        [Authorize(Roles = "admin")]
        public IActionResult AdminTest()
        {
            return Ok(new { message = "✅ Admin token geçerli, erişim başarılı." });
        }

        [HttpGet("anonymous")]
        [AllowAnonymous]
        public IActionResult Anonymous()
        {
            return Ok(new { message = "Bu endpoint JWT olmadan da erişilebilir." });
        }
    }
}
