using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QRRestaurantApp.Backend.DTOs.TableSessionDtos;
using QRRestaurantApp.Backend.Helpers;
using QRRestaurantApp.Backend.Services.TableSessionsServices;

namespace QRRestaurantApp.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableSessionsController : ControllerBase
    {
        private readonly ITableSessionService _tableSessionService;

        public TableSessionsController(ITableSessionService tableSessionService)
        {
            _tableSessionService = tableSessionService;
        }



        [HttpPost("createSession")]
        public async Task<IActionResult> CreateTableSessionLog([FromBody] DTOs.TableSessionDtos.CreateTableSessionLogDto createTableSessionLogDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<ResultTableSessionLogDto>.FailResponse("Geçersiz Veri"));
            }

            var response = await _tableSessionService.CreateTableSessionLogAsync(createTableSessionLogDto);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }

}
