using BasarsoftInternship.Entities;
using BasarsoftInternship.Services;
using Microsoft.AspNetCore.Mvc;
using BasarsoftInternship.Models;

namespace BasarsoftInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private readonly IPointService _pointService;

        public PointController(IPointService pointService)
        {
            _pointService = pointService;
        }

        [HttpGet]
        public ActionResult<Response<List<Point>>> Get()
        {
            try
            {
                var points = _pointService.Get();
                if (points.Count == 0)
                {
                    return NotFound(new Response<List<Point>>(404, "No points found"));
                }
                return Ok(new Response<List<Point>>(200, "Points retrieved successfully", points));
            }
            catch (Exception ex)
            {
                // Veritabanı bağlantısı hatası durumunu ele alıyoruz
                return StatusCode(500, new Response<List<Point>>(500, "An error occurred while retrieving points: " + ex.Message));
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Response<Point>> Get(long id)
        {
            try
            {
                var point = _pointService.Get(id);
                if (point == null)
                {
                    return NotFound(new Response<Point>(404, "Point not found"));
                }
                return Ok(new Response<Point>(200, "Point retrieved successfully", point));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Response<Point>(500, "An error occurred while retrieving the point: " + ex.Message));
            }
        }

        [HttpPost]
        public ActionResult<Response<Point>> Add(Point point)
        {
            try
            {
                var createdPoint = _pointService.Add(point);
                return CreatedAtAction(nameof(Get), new { id = createdPoint.Id },
                    new Response<Point>(201, "Point created successfully", createdPoint));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Response<Point>(500, "An error occurred while creating the point: " + ex.Message));
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<Response<Point>> Update(long id, Point point)
        {
            try
            {
                var existingPoint = _pointService.Get(id);
                if (existingPoint == null)
                {
                    return NotFound(new Response<Point>(404, "Point not found"));
                }

                _pointService.Update(id, point);
                return Ok(new Response<Point>(200, "Point updated successfully", point));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Response<Point>(500, "An error occurred while updating the point: " + ex.Message));
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Response<Point>> Delete(long id)
        {
            try
            {
                var existingPoint = _pointService.Get(id);
                if (existingPoint == null)
                {
                    return NotFound(new Response<Point>(404, "Point not found"));
                }

                _pointService.Delete(id);
                return Ok(new Response<Point>(200, "Point deleted successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Response<Point>(500, "An error occurred while deleting the point: " + ex.Message));
            }
        }
    }
}
