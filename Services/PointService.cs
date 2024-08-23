using BasarsoftInternship.Data;
using BasarsoftInternship.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasarsoftInternship.Services
{
    public class PointService : GenericService<Point>
    {
        public PointService(AppDbContext context) : base(context)
        {
        }
    }
}
