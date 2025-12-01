using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SOE_MDEIS_BACKEND_GESTION.DTOs;
using SOE_MDEIS_BACKEND_GESTION.Services.Interfaces;

namespace SOE_MDEIS_BACKEND_GESTION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> GetAll()
        {
            var clientes = await _clienteService.GetAllAsync();
            return Ok(clientes);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ClienteDto>> GetById(int id)
        {
            var cliente = await _clienteService.GetByIdAsync(id);
            if (cliente is null) return NotFound();

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<ClienteDto>> Create([FromBody] ClienteCreateDto dto)
        {
            var created = await _clienteService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.ClienteId }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClienteUpdateDto dto)
        {
            var updated = await _clienteService.UpdateAsync(id, dto);
            if (!updated) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _clienteService.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
