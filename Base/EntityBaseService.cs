using AppDisney.Models;
using AppDisney.Repositories.Implements;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDisney.Services.Implements
{
    public class EntityBaseService<TEntity> : IEntityBaseService<TEntity> where TEntity : class
    {
        private readonly Models.IEntityBaseRepository<TEntity> _repository;

        public EntityBaseService(Models.IEntityBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public Task DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
