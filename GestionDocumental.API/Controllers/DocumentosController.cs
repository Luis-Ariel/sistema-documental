using GestionDocumental.Core.Entities;
using GestionDocumental.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestionDocumental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentosController : ControllerBase
    {
        private readonly DocumentosService _documentosService;
        private readonly ILogger<DocumentosController> _logger;

        public DocumentosController(DocumentosService documentosService, ILogger<DocumentosController> logger)
        {
            _documentosService = documentosService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var documentos = await _documentosService.GetAllAsync();
                return Ok(documentos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los documentos.");
                return StatusCode(500, "Ocurrió un error al obtener los documentos.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var documento = await _documentosService.GetByIdAsync(id);
                return Ok(documento);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex.Message);
                return NotFound(new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error inesperado al buscar el documento con ID {id}.");
                return StatusCode(500, new { mensaje = "Ocurrió un error inesperado al buscar el documento." });
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Documento documento)
        {
            if (documento == null)
                return BadRequest("El cuerpo de la solicitud no puede estar vacío.");

            try
            {
                var created = await _documentosService.CreateAsync(documento);
                return CreatedAtAction(nameof(GetById), new { id = created.ID_Documento }, created);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado al crear el documento.");
                return StatusCode(500, "Ocurrió un error al crear el documento.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Documento documento)
        {
            if (documento == null)
                return BadRequest("El cuerpo de la solicitud no puede estar vacío.");

            if (id != documento.ID_Documento)
                return BadRequest($"El ID de la URL ({id}) no coincide con el ID del documento ({documento.ID_Documento}).");

            try
            {
                var updated = await _documentosService.UpdateAsync(documento);
                if (!updated)
                    return NotFound($"No se encontró un documento con ID {id} o no se pudo actualizar.");

                return Ok("Documento actualizado correctamente.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error inesperado al actualizar el documento con ID {id}.");
                return StatusCode(500, "Ocurrió un error al actualizar el documento.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleted = await _documentosService.DeleteAsync(id);
                if (!deleted)
                    return NotFound($"No se encontró un documento con ID {id} o no se pudo eliminar.");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error inesperado al eliminar el documento con ID {id}.");
                return StatusCode(500, "Ocurrió un error al eliminar el documento.");
            }
        }
    }
}
