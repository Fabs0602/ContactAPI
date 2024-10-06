using ContatoApi.Models;
using ContatoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContatoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        private readonly ContatoService _contatoService;

        public ContatosController(ContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contato>>> Get() => 
            await _contatoService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Contato>> Get(string id)
        {
            var contato = await _contatoService.GetAsync(id);
            if (contato == null)
            {
                return NotFound();
            }
            return contato;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Contato contato)
        {
            if (contato == null)
            {
                return BadRequest("Contato não pode ser nulo.");
            }

            // Remova a validação do campo Id
            contato.Id = null;

            await _contatoService.CreateAsync(contato);
            return CreatedAtAction(nameof(Get), new { id = contato.Id }, contato);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Contato contato)
        {
            var existingContato = await _contatoService.GetAsync(id);
            if (existingContato == null)
            {
                return NotFound();
            }
            await _contatoService.UpdateAsync(id, contato);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var contato = await _contatoService.GetAsync(id);
            if (contato == null)
            {
                return NotFound();
            }
            await _contatoService.DeleteAsync(id);
            return NoContent();
        }
    }
}