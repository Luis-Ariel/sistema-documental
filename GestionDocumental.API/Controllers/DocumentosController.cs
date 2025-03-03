using GestionDocumental.Core.Entities;
using GestionDocumental.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestionDocumental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentosController : ControllerBase
    {
        private readonly DocumentosService _documentosService;

        public DocumentosController(DocumentosService documentosService)
        {
            _documentosService = documentosService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var documentos = await _documentosService.GetAllAsync();
            return Ok(documentos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var documento = await _documentosService.GetByIdAsync(id);
            if (documento == null) return NotFound();
            return Ok(documento);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Documento documento)
        {
            if (documento == null) return BadRequest();
            var created = await _documentosService.CreateAsync(documento);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Documento documento)
        {
            if (id != documento.Id) return BadRequest();
            var updated = await _documentosService.UpdateAsync(documento);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _documentosService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}