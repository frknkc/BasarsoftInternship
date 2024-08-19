using BasarsoftInternship.Entities;
using BasarsoftInternship.Data;
using Microsoft.EntityFrameworkCore;

namespace BasarsoftInternship.Services
{
    public class PointService : IPointService
    {
        private readonly AppDbContext _context;

        public PointService(AppDbContext context)
        {
            _context = context;
        }

        public List<Point> Get()
        {
            return _context.Points.ToList();
        }

        public Point Add(Point point)
        {
            _context.Points.Add(point);
            _context.SaveChanges();
            return point;
        }

        public Point Get(long id)
        {
            return _context.Points.Find(id);
        }

        public Point Update(long id, Point point)
        {
            var existingPoint = _context.Points.Find(id);
            if (existingPoint != null)
            {
                existingPoint.PointX = point.PointX;
                existingPoint.PointY = point.PointY;
                existingPoint.Name = point.Name;
                _context.SaveChanges();
            }
            return existingPoint;
        }

        public void Delete(long id)
        {
            var point = _context.Points.Find(id);
            if (point != null)
            {
                _context.Points.Remove(point);
                _context.SaveChanges();
            }
        }
    }
}
