using BasarsoftInternship.Entities;
using BasarsoftInternship.Services;
using Microsoft.AspNetCore.Http;
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
        public ActionResult<List<Point>> Get()
        {
            var points = _pointService.Get();
            if(points.Count == 0)
            {
                return NotFound(new Response<List<Point>>(404, "No points found"));
            }
            return Ok(new Response<List<Point>>(200, "Points retrieved successfully", points));
        }

        [HttpGet("{id}")]
        public ActionResult<Point> Get(long id)
        {
            var point = _pointService.Get(id);
            if (point == null)
            {
                return NotFound(new Response<Point>(404, "Point not found"));
            }
            return Ok(new Response<Point>(200, "Point retrieved successfully", point));
        }

        [HttpPost]
        public ActionResult<Point> Add(Point point)
        {
            var createdPoint = _pointService.Add(point);
            return CreatedAtAction(nameof(Get), new { id = createdPoint.Id },
                new Response<Point>(201, "Point created successfully", createdPoint));
        }

        [HttpPut("{id}")]
        public ActionResult<Response<Point>> Update(long id, Point point)
        {
            var existingPoint = _pointService.Get(id);
            if (existingPoint == null)
            {
                return NotFound(new Response<Point>(404, "Point not found"));
            }

            _pointService.Update(id, point);
            return Ok(new Response<Point>(200, "Point updated successfully", existingPoint));
        }

        [HttpDelete("{id}")]
        public ActionResult<Response<Point>> Delete(long id)
        {
            var existingPoint = _pointService.Get(id);
            if (existingPoint == null)
            {
                return NotFound(new Response<Point>(404, "Point not found"));
            }

            _pointService.Delete(id);
            return Ok(new Response<Point>(200, "Point deleted successfully"));
        }

    }
}
