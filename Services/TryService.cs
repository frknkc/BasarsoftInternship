using BasarsoftInternship.Entities;

namespace BasarsoftInternship.Services
{
    public class TryService : GenericService<Try>
    {
        public TryService(GenericRepository<Try> repository) : base(repository)
        {
        }
    }
}
