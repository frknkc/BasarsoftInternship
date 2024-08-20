using BasarsoftInternship.Entities;
using BasarsoftInternship.Services;

namespace BasarsoftInternship.Services
{
    public class PointService : GenericService<Point>
    {
        public PointService(GenericRepository<Point> repository) : base(repository)
        {
        }
    }
}





//using BasarsoftInternship.Entities;
//using BasarsoftInternship.Data;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace BasarsoftInternship.Services
//{
//    public class PointService : IPointService
//    {
//        private readonly AppDbContext _context;

//        public PointService(AppDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<List<Point>> GetAsync()
//        {
//            return await _context.Points.ToListAsync();
//        }
//        public Point Add(Point point)
//        {
//            _context.Points.Add(point);
//            _context.SaveChanges();
//            return point;
//        }    

//        public async Task<Point> AddAsync(Point point)
//        {
//            await _context.Points.AddAsync(point);
//            await _context.SaveChangesAsync();
//            return point;
//        }   

//        public async Task<Point> GetAsync(long id)
//        {
//            return await _context.Points.FindAsync(id);
//        }

//        public async Task<Point> UpdateAsync(long id, Point point)
//        {
//            var existingPoint = await _context.Points.FindAsync(id);
//            if (existingPoint != null)
//            {
//                existingPoint.PointX = point.PointX;
//                existingPoint.PointY = point.PointY;
//                existingPoint.Name = point.Name;
//                await _context.SaveChangesAsync();
//            }
//            return existingPoint;
//        }

//        public async Task DeleteAsync(long id)
//        {
//            var point = await _context.Points.FindAsync(id);
//            if (point != null)
//            {
//                _context.Points.Remove(point);
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}
