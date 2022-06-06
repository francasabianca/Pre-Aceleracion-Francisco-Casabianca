
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AppDisney.Models
{
    public interface IEntityBaseRepository<TEntity> where TEntity : class 
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task DeleteAsync(int id);       
    }
}
