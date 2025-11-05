using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QRRestaurantApp.Backend.DTOs.TableDtos;
using QRRestaurantApp.Backend.Services.TableServices;

namespace QRRestaurantApp.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly ITableService _tableService;

        public TablesController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _tableService.GetAllTableAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTable(CreateTableDto createTableDto)
        {
            var values= await _tableService.CreateTableAsync(createTableDto);
            return Ok(values);
        }

    }
}
