using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QRRestaurantApp.Backend.DTOs.OptionDtos;
using QRRestaurantApp.Backend.Services.OptionServices;

namespace QRRestaurantApp.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOptionsController : ControllerBase
    {
        private readonly IOptionGroupService _optionGroupService;
        public ProductOptionsController(IOptionGroupService optionGroupService)
        {
            _optionGroupService = optionGroupService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOptionGroups()
        {
            var result = await _optionGroupService.GetAllOptionGroupAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOptionGroup(CreateOptionGroupDto createOptionGroupDto)
        {
            var result = await _optionGroupService.CreateOptionGroupAsync(createOptionGroupDto);
            return Ok(result);
        }

    }
}
