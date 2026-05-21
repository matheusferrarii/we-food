using Microsoft.AspNetCore.Mvc;

namespace we_food.contexts.restaurant.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuItemController : Controller
    {
        public MenuItemController()
        {
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MenuItemCreateDTO dto)
        {
            try
            {
                var result = await _createMenuItemUseCase.Run(dto);
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
                var result = await _getMenuItemUseCase.Run();
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
                var result = await _getMenuItemByIdUseCase.Run(id);
                return Ok(result);
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
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
    }
