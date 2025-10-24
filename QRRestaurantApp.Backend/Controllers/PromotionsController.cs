using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QRRestaurantApp.Backend.DTOs.PromotionDtos;
using QRRestaurantApp.Backend.Services.PromotionServices;

namespace QRRestaurantApp.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionsController : ControllerBase
    {
        private readonly IPromotionService _promotionService;

        public PromotionsController(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        [HttpGet]
        public async Task<IActionResult> PromotionList()
        {
            var values = await _promotionService.GetAllPromotionAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePromotion(CreatePromotionDto createPromotionDto)
        {
            var values = await _promotionService.CreatePromotionAsync(createPromotionDto);
            return Ok(values);
        }
    }
}
