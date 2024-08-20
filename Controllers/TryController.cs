using BasarsoftInternship.Entities;
using BasarsoftInternship.Models;
using BasarsoftInternship.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasarsoftInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TryController : ControllerBase
    {
        private readonly IGenericService<Try> _tryService;

        public TryController(IGenericService<Try> tryService)
        {
            _tryService = tryService;
        }

        // Get all Try entities
        [HttpGet]
        public async Task<ActionResult<Response<IEnumerable<Try>>>> GetTries()
        {
            var tries = await _tryService.GetAllAsync();
            var response = new Response<IEnumerable<Try>>(200, "Tries retrieved successfully", tries);
            return Ok(response);
        }

        // Get a single Try entity by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Response<Try>>> GetTry(int id)
        {
            var tryEntity = await _tryService.GetByIdAsync(id);
            if (tryEntity == null)
            {
                var response = new Response<Try>(404, "Try not found", null);
                return NotFound(response);
            }
            var successResponse = new Response<Try>(200, "Try retrieved successfully", tryEntity);
            return Ok(successResponse);
        }

        // Create a new Try entity
        [HttpPost]
        public async Task<ActionResult<Response<Try>>> CreateTry(Try tryEntity)
        {
            var createdTry = await _tryService.AddAsync(tryEntity);
            var response = new Response<Try>(201, "Try created successfully", createdTry);
            return CreatedAtAction(nameof(GetTry), new { id = createdTry.id }, response);
        }

        // Update an existing Try entity
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTry(int id, Try tryEntity)
        {
            if (id != tryEntity.id)
            {
                var response = new Response<Try>(400, "ID mismatch", null);
                return BadRequest(response);
            }

            var updatedTry = await _tryService.UpdateAsync(id, tryEntity);
            if (updatedTry == null)
            {
                var response = new Response<Try>(404, "Try not found", null);
                return NotFound(response);
            }
;
            return Ok(new Response<Try>(204, "Try deleted successfully", null)); // NoContent doesn't accept a response body, so this is for successful updates.
        }

        // Delete a Try entity by id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTry(int id)
        {
            await _tryService.DeleteAsync(id);
            return Ok(new Response<Try>(204, "Try deleted successfully", null)) ; // NoContent doesn't accept a response body, so this is for successful deletes.
        }
    }
}
