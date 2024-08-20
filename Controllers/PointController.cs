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
        private readonly IGenericService<Point> _pointService;

        public PointController(IGenericService<Point> pointService)
        {
            _pointService = pointService;
        }

        [HttpGet]
        public async Task<ActionResult<Response<List<Point>>>> GetAllAsync()
        {
            var points = await _pointService.GetAllAsync();
            return Ok(new Response<List<Point>>(200, "Points retrieved successfully", points));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response<Point>>> GetByIdAsync(long id)
        {
            var point = await _pointService.GetByIdAsync(id);
            if (point == null)
            {
                return NotFound(new Response<Point>(404, "Point not found"));
            }
            return Ok(new Response<Point>(200, "Point retrieved successfully", point));
        }

        [HttpPost]
        public async Task<ActionResult<Response<Point>>> AddAsync(Point point)
        {
            var createdPoint = await _pointService.AddAsync(point);

            var response = new Response<Point>(201, "Point created successfully", createdPoint);
            return StatusCode(201, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response<Point>>> UpdateAsync(long id, Point point)
        {
            var updatedPoint = await _pointService.UpdateAsync(id, point);
            if (updatedPoint == null)
            {
                return NotFound(new Response<Point>(404, "Point not found"));
            }
            return Ok(new Response<Point>(200, "Point updated successfully", updatedPoint));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<Point>>> DeleteAsync(long id)
        {
            var point = await _pointService.GetByIdAsync(id);
            if (point == null)
            {
                return NotFound(new Response<Point>(404, "Point not found"));
            }
            await _pointService.DeleteAsync(id);
            return Ok(new Response<Point>(200, "Point deleted successfully"));
        }
    }
}



//using BasarsoftInternship.Entities;
//using BasarsoftInternship.Services;
//using Microsoft.AspNetCore.Mvc;
//using BasarsoftInternship.Models;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using System;

//namespace BasarsoftInternship.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PointController : ControllerBase
//    {
//        private readonly IPointService _pointService;

//        public PointController(IPointService pointService)
//        {
//            _pointService = pointService;
//        }

//        [HttpGet]
//        public async Task<ActionResult<Response<List<Point>>>> GetAsync()
//        {
//            try
//            {
//                var points = await _pointService.GetAsync();
//                if (points.Count == 0)
//                {
//                    return NotFound(new Response<List<Point>>(404, "No points found"));
//                }
//                return Ok(new Response<List<Point>>(200, "Points retrieved successfully", points));
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, new Response<List<Point>>(500, "An error occurred while retrieving points: " + ex.Message));
//            }
//        }

//        [HttpGet]
//        [Route("{id}")]
//        public async Task<ActionResult<Response<Point>>> GetAsync(long id)
//        {
//            try
//            {
//                var point = await _pointService.GetAsync(id);
//                if (point == null)
//                {
//                    return NotFound(new Response<Point>(404, "Point not found"));
//                }
//                return Ok(new Response<Point>(200, "Point retrieved successfully", point));
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, new Response<Point>(500, "An error occurred while retrieving the point: " + ex.Message));
//            }
//        }
//        [HttpPost]
//        public ActionResult<Response<Point>> Add(Point point)
//        {
//            try
//            {
//                var createdPoint = _pointService.Add(point);
//                return CreatedAtAction(nameof(GetAsync), new { id = createdPoint.Id },
//                    new Response<Point>(201, "Point created successfully", createdPoint));
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, new Response<Point>(500, "An error occurred while creating the point: " + ex.Message));
//            }
//        }

//        [HttpPut]
//        [Route("{id}")]
//        public async Task<ActionResult<Response<Point>>> UpdateAsync(long id, Point point)
//        {
//            try
//            {
//                var existingPoint = await _pointService.GetAsync(id);
//                if (existingPoint == null)
//                {
//                    return NotFound(new Response<Point>(404, "Point not found"));
//                }

//                var updatedPoint = await _pointService.UpdateAsync(id, point);
//                return Ok(new Response<Point>(200, "Point updated successfully", updatedPoint));
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, new Response<Point>(500, "An error occurred while updating the point: " + ex.Message));
//            }
//        }

//        [HttpDelete]
//        [Route("{id}")]
//        public async Task<ActionResult<Response<Point>>> DeleteAsync(long id)
//        {
//            try
//            {
//                var existingPoint = await _pointService.GetAsync(id);
//                if (existingPoint == null)
//                {
//                    return NotFound(new Response<Point>(404, "Point not found"));
//                }

//                await _pointService.DeleteAsync(id);
//                return Ok(new Response<Point>(200, "Point deleted successfully"));
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, new Response<Point>(500, "An error occurred while deleting the point: " + ex.Message));
//            }
//        }
//    }
//}
