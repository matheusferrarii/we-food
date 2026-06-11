using Microsoft.AspNetCore.Mvc;
using we_food.contexts.restaurant.DTOS;
using we_food.contexts.restaurant.Interfaces;

namespace we_food.contexts.restaurant.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuItemController : ControllerBase
    {
        private readonly ICreateMenuItemUseCase _createMenuItemUseCase;
        private readonly IGetMenuItemUseCase _getMenuItemUseCase;
        private readonly IGetByIdMenuItemUseCase _getMenuItemByIdUseCase;
        private readonly IUpdateMenuItemUseCase _updateMenuItemUseCase;

        public MenuItemController(
            ICreateMenuItemUseCase createMenuItemUseCase,
            IGetMenuItemUseCase getMenuItemUseCase,
            IGetByIdMenuItemUseCase getMenuItemByIdUseCase,
            IUpdateMenuItemUseCase updateMenuItemUseCase)
        {
            _createMenuItemUseCase = createMenuItemUseCase;
            _getMenuItemUseCase = getMenuItemUseCase;
            _getMenuItemByIdUseCase = getMenuItemByIdUseCase;
            _updateMenuItemUseCase = updateMenuItemUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MenuItemCreateDTO dto)
        {
            try
            {
                var result = await _createMenuItemUseCase.Run(dto);
                return Ok(MenuItemResponseDTO.From(result));
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
                var result = await _getMenuItemUseCase.Run();
                return Ok(result.Select(MenuItemResponseDTO.From));
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
                var result = await _getMenuItemByIdUseCase.Run(id);
                return Ok(MenuItemResponseDTO.From(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] MenuItemUpdateDTO dto)
        {
            try
            {
                var result = await _updateMenuItemUseCase.Run(id, dto);
                return Ok(MenuItemResponseDTO.From(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
