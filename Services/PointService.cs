using BasarsoftInternship.Entities;

namespace BasarsoftInternship.Services
{
    public class PointService : IPointService
    {
        private static List<Point> _pointList = new List<Point>();

        public List<Point> Get()
        {
            return _pointList;
        }

        public Point Add(Point point)
        {
            point.Id = _pointList.Count + 1;
            _pointList.Add(point);
            return point;
        }

        public Point Get(long id)
        {
            var point = _pointList.FirstOrDefault(p => p.Id == id);
            if (point == null)
            {
                return null;
            }
            return point;
        }

        public Point Update(long id, Point point)
        {
            var existingPoint = _pointList.FirstOrDefault(p => p.Id == id);
            if (existingPoint != null)
            {
                existingPoint.PointX = point.PointX;
                existingPoint.PointY = point.PointY;
                existingPoint.Name = point.Name;
            }
            return existingPoint;
        }

        public void Delete(long id)
        {
            var existingPoint = _pointList.FirstOrDefault(p => p.Id == id);
            if (existingPoint != null)
            {
                _pointList.Remove(existingPoint);
            }
        }   
       
    }
}
