using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasarsoftInternship.Services
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        private readonly GenericRepository<TEntity> _repository;

        public GenericService(GenericRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task<TEntity> UpdateAsync(object id, TEntity entity)
        {
            return await _repository.UpdateAsync(id, entity);
        }

        public async Task DeleteAsync(object id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
