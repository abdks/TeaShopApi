using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApiDataAccessLayer.Abstract;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;

        public StatController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }
        [HttpGet("TDrinkAvgPrice")]
        public IActionResult Get()
        {
            return Ok(_statisticsService.TDrinkAvgPrice());
        }
        [HttpGet("TDrinkCount")]
        public IActionResult get2()
        {
            return Ok(_statisticsService.TDrinkCount());
        }
        [HttpGet("TLastDrinkName")]
        public IActionResult get3()
        {
            return Ok(_statisticsService.TLastDrinkName());
        }
        [HttpGet("TMaxPriceDrink")]
        public IActionResult get4()
        {
            return Ok(_statisticsService.TMaxPriceDrink());
        }
    }
}
