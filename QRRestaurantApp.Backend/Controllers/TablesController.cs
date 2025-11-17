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
        public async Task<IActionResult> TableList()
        {
            var values = await _tableService.GetAllTableAsync();
            return Ok(values);
        }
        [HttpGet("code/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var result= await _tableService.GetByCodeAsync(code);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTable(CreateTableDto createTableDto)
        {
            var values= await _tableService.CreateTableAsync(createTableDto);
            return Ok(values);
        }

    }
}
