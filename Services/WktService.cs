using BasarsoftInternship.Data;
using BasarsoftInternship.Entities;

namespace BasarsoftInternship.Services
{
    public class WktService : GenericService<Wkt>
    {
        public WktService(AppDbContext context) : base(context)
        {
        }
    }
}
