using Microsoft.AspNetCore.Mvc;
using QRRestaurantApp.Backend.DTOs.OptionValueDtos;
using QRRestaurantApp.Backend.Services.OptionValueServices;

namespace QRRestaurantApp.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOptionValuesController : ControllerBase
    {
        private readonly IOptionValueService _optionValueService;

        public ProductOptionValuesController(IOptionValueService optionValueService)
        {
            _optionValueService = optionValueService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOptionValues()
        {
            var result = await _optionValueService.GetAllOptionValueAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOptionGroup(CreateOptionValueDto createOptionValueDto)
        {
            var result = await _optionValueService.CreateOptionValueAsync(createOptionValueDto);
            return Ok(result);
        }
    }
}
