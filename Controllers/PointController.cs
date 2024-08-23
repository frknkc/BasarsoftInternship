using BasarsoftInternship.Entities;
using BasarsoftInternship.Services;
using Microsoft.AspNetCore.Mvc;
using BasarsoftInternship.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasarsoftInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PointController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<Response<List<Point>>>> GetAllAsync()
        {
            var points = await _unitOfWork.PointService.GetAllAsync();
            return Ok(new Response<List<Point>>(200, "Points retrieved successfully", points));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response<Point>>> GetByIdAsync(long id)
        {
            var point = await _unitOfWork.PointService.GetByIdAsync(id);
            if (point == null)
            {
                return NotFound(new Response<Point>(404, "Point not found"));
            }
            return Ok(new Response<Point>(200, "Point retrieved successfully", point));
        }

        [HttpPost]
        public async Task<ActionResult<Response<Point>>> AddAsync(Point point)
        {
            var createdPoint = await _unitOfWork.PointService.AddAsync(point);
            await _unitOfWork.SaveChangesAsync(); // Ensure changes are saved

            var response = new Response<Point>(201, "Point created successfully", createdPoint);
            return StatusCode(201, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response<Point>>> UpdateAsync(long id, Point point)
        {
            var existingPoint = await _unitOfWork.PointService.GetByIdAsync(id);
            if (existingPoint == null)
            {
                return NotFound(new Response<Point>(404, "Point not found"));
            }

            var updatedPoint = await _unitOfWork.PointService.UpdateAsync(id, point);
            await _unitOfWork.SaveChangesAsync(); // Ensure changes are saved

            return Ok(new Response<Point>(200, "Point updated successfully", updatedPoint));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<Point>>> DeleteAsync(long id)
        {
            var point = await _unitOfWork.PointService.GetByIdAsync(id);
            if (point == null)
            {
                return NotFound(new Response<Point>(404, "Point not found"));
            }

            await _unitOfWork.PointService.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync(); // Ensure changes are saved

            return Ok(new Response<Point>(200, "Point deleted successfully"));
        }
    }
}
