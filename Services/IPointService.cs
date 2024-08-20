using BasarsoftInternship.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasarsoftInternship.Services
{
    public interface IPointService
    {
        Task<List<Point>> GetAsync();
        Point Add(Point point);
        Task<Point> GetAsync(long id);
        Task<Point> UpdateAsync(long id, Point point);
        Task DeleteAsync(long id);
    }
}
