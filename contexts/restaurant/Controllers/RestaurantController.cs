using Microsoft.AspNetCore.Mvc;
using we_food.contexts.restaurant.DTOS;
using we_food.contexts.restaurant.UseCases;

namespace we_food.contexts.restaurant.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController : Controller
    {
        private readonly CreateRestaurantUseCase _createRestauranteUseCase;
        private readonly GetRestaurantUseCase _getRestauranteUseCase;
        private readonly GetByIdRestaurantUseCase _getRestauranteByIdUseCase;
        private readonly UpdateRestaurantUseCase _updateRestauranteUseCase;
        private readonly UpdateRestaurantStatusUseCase _updateRestauranteStatusUseCase;
        private readonly GetByIdRestaurantMenuUseCase _getRestauranteMenuByIdUseCase;
        public RestaurantController(
            CreateRestaurantUseCase createRestauranteUseCase, 
            GetRestaurantUseCase getRestauranteUseCase, 
            GetByIdRestaurantUseCase getRestauranteByIdUseCase,
            UpdateRestaurantUseCase updateRestauranteUseCase,
            UpdateRestaurantStatusUseCase updateRestauranteStatusUseCase,
            GetByIdRestaurantMenuUseCase getRestauranteMenuByIdUseCase
            )
        {
            _createRestauranteUseCase = createRestauranteUseCase;
            _getRestauranteUseCase = getRestauranteUseCase;
            _getRestauranteByIdUseCase = getRestauranteByIdUseCase;
            _updateRestauranteUseCase = updateRestauranteUseCase;
            _updateRestauranteStatusUseCase = updateRestauranteStatusUseCase;
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
                var result = await _getRestauranteMenuByIdUseCase.Run(id, true);
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
