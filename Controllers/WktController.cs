using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BasarsoftInternship.Entities;
using BasarsoftInternship.Services;
using BasarsoftInternship.Models;

namespace BasarsoftInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WktController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public WktController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<Response<List<Wkt>>>> GetAllAsync()
        {
            var wkts = await _unitOfWork.WktService.GetAllAsync();
            return Ok(new Response<List<Wkt>>(200, "Wkts retrieved successfully", wkts));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response<Wkt>>> GetByIdAsync(long id)
        {
            var wkt = await _unitOfWork.WktService.GetByIdAsync(id);
            if (wkt == null)
            {
                return NotFound(new Response<Wkt>(404, "Wkt not found"));
            }
            return Ok(new Response<Wkt>(200, "Wkt retrieved successfully", wkt));
        }

        [HttpPost]
        public async Task<ActionResult<Response<Wkt>>> AddAsync(Wkt wkt)
        {
            var createdWkt = await _unitOfWork.WktService.AddAsync(wkt);
            await _unitOfWork.SaveChangesAsync(); // Ensure changes are saved

            var response = new Response<Wkt>(201, "Wkt created successfully", createdWkt);
            return StatusCode(201, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response<Wkt>>> UpdateAsync(long id, Wkt wkt)
        {
            var existingWkt = await _unitOfWork.WktService.GetByIdAsync(id);
            if (existingWkt == null)
            {
                return NotFound(new Response<Wkt>(404, "Wkt not found"));
            }

            var updatedWkt = await _unitOfWork.WktService.UpdateAsync(id, wkt);
            await _unitOfWork.SaveChangesAsync(); // Ensure changes are saved

            var response = new Response<Wkt>(200, "Wkt updated successfully", updatedWkt);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<Wkt>>> DeleteAsync(long id)
        {
            var existingWkt = await _unitOfWork.WktService.GetByIdAsync(id);
            if (existingWkt == null)
            {
                return NotFound(new Response<Wkt>(404, "Wkt not found"));
            }

            await _unitOfWork.WktService.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync(); // Ensure changes are saved

            var response = new Response<Wkt>(200, "Wkt deleted successfully");
            return Ok(response);
        }
    }
}
