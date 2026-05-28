using Microsoft.AspNetCore.Mvc;
using we_food.contexts.restaurant.DTOS;
using we_food.contexts.restaurant.Interfaces;
namespace we_food.contexts.restaurant.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController : Controller
    {
        private readonly ICreateRestaurantUseCase _createRestauranteUseCase;
        private readonly IGetRestaurantUseCase _getRestauranteUseCase;
        private readonly IGetByIdRestaurantUseCase _getRestauranteByIdUseCase;
        private readonly IUpdateRestaurantUseCase _updateRestauranteUseCase;
        private readonly IUpdateRestaurantStatusUseCase _updateRestauranteStatusUseCase;
        private readonly IGetByIdRestaurantMenuUseCase _getRestauranteMenuByIdUseCase;
        public RestaurantController(
            ICreateRestaurantUseCase createRestauranteUseCase, 
            IGetRestaurantUseCase getRestauranteUseCase, 
            IGetByIdRestaurantUseCase getRestauranteByIdUseCase,
            IUpdateRestaurantUseCase updateRestauranteUseCase,
            IUpdateRestaurantStatusUseCase updateRestauranteStatusUseCase,
            IGetByIdRestaurantMenuUseCase getRestauranteMenuByIdUseCase
            )
        {
            _createRestauranteUseCase = createRestauranteUseCase;
            _getRestauranteUseCase = getRestauranteUseCase;
            _getRestauranteByIdUseCase = getRestauranteByIdUseCase;
            _updateRestauranteUseCase = updateRestauranteUseCase;
            _updateRestauranteStatusUseCase = updateRestauranteStatusUseCase;
            _getRestauranteMenuByIdUseCase = getRestauranteMenuByIdUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RestaurantCreateDTO dto)
        {
            try
            {
                var result = await _createRestauranteUseCase.Run(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _getRestauranteUseCase.Run();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _getRestauranteByIdUseCase.Run(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/menu")]
        public async Task<IActionResult> GetMenu(Guid id)
        {
            try
            {
                var result = await _getRestauranteMenuByIdUseCase.Run(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] RestaurantUpdateDTO dto)
        {
            try
            {
                var result = await _updateRestauranteUseCase.Run(id, dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] RestaurantUpdateStatusDTO dto)
        {
            try
            {
                var result = await _updateRestauranteStatusUseCase.Run(id, dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
