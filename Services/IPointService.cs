using BasarsoftInternship.Entities;

namespace BasarsoftInternship.Services
{
    public interface IPointService
    {
        List<Point> Get();
        Point Add(Point point);
        Point Get(long id);
        Point Update(long id, Point point);
        void Delete(long id);
    }
}
