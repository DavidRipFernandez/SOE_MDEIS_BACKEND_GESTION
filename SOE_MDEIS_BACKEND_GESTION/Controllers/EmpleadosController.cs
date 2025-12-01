using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SOE_MDEIS_BACKEND_GESTION.DTOs;
using SOE_MDEIS_BACKEND_GESTION.Services.Interfaces;

namespace SOE_MDEIS_BACKEND_GESTION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadosController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpleadoDto>>> GetAll()
        {
            var empleados = await _empleadoService.GetAllAsync();
            return Ok(empleados);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EmpleadoDto>> GetById(int id)
        {
            var empleado = await _empleadoService.GetByIdAsync(id);
            if (empleado is null) return NotFound();

            return Ok(empleado);
        }

        [HttpPost]
        public async Task<ActionResult<EmpleadoDto>> Create([FromBody] EmpleadoCreateDto dto)
        {
            var created = await _empleadoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.EmpleadoId }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] EmpleadoUpdateDto dto)
        {
            var updated = await _empleadoService.UpdateAsync(id, dto);
            if (!updated) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _empleadoService.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
