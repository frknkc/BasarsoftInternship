using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasarsoftInternship.Services
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(object id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(object id, TEntity entity);
        Task DeleteAsync(object id);
    }
}