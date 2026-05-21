    using Microsoft.AspNetCore.Mvc;
    using we_food.contexts.order.DTOS;
    using we_food.contexts.order.UseCases;

namespace we_food.contexts.order.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly CreateOrderUseCase _createOrderUseCase;
        private readonly GetOrderUseCase _getOrderUseCase;
        private readonly GetByIdOrderUseCase _getByIdOrderUseCase;
        private readonly UpdateOrderStatusUseCase _updateOrderStatusUseCase;

        public OrderController(CreateOrderUseCase createOrderUseCase, GetOrderUseCase getOrderUseCase, GetByIdOrderUseCase getByIdOrderUseCase, UpdateOrderStatusUseCase updateOrderStatusUseCase)
        {
            _createOrderUseCase = createOrderUseCase;
            _getOrderUseCase = getOrderUseCase;
            _getByIdOrderUseCase = getByIdOrderUseCase;
            _updateOrderStatusUseCase = updateOrderStatusUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderDTO dto)
        {
            try
            {
                var result = await _createOrderUseCase.Run(dto);
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
                var result = await _getOrderUseCase.Run();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var result = await _getByIdOrderUseCase.Run(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] UpdateOrderStatusDTO dto)
        {
            try
            {
                var result = await _updateOrderStatusUseCase.Run(id, dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
