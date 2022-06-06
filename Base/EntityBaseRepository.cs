using AppDisney.DataAccess;
using AppDisney.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;


namespace AppDisney.Repositories.Implements
{
    public class EntityBaseRepository<TEntity> : IEntityBaseRepository<TEntity> where TEntity : class
    { 

        private readonly AppDBContext _context;

        

        public EntityBaseRepository(AppDBContext context)
        {
            _context = context;            
        }       

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            EntityEntry entityEntry = _context.Entry<TEntity>(entity);
            entityEntry.State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }
       
        public async Task<IEnumerable<TEntity>> GetAllAsync() => 
            await _context.Set<TEntity>().ToListAsync();              
    } 
}
