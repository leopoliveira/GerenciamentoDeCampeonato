using GerenciamentoDeCampeonato.Contexts;
using GerenciamentoDeCampeonato.Models.Entities;
using GerenciamentoDeCampeonato.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeCampeonato.Repositories.Repositories
{
    public class DefaultRepository<TEntity> : IDefaultRepository<TEntity> where TEntity : DefaultEntity
    {
        #region "Private Methods"

        private readonly Context _context;

        #endregion

        #region "Context Methods"
        public DefaultRepository(Context context)
        {
            _context = context;
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<int> CreateOrEditAsync(TEntity entity)
        {
            bool exists = _context.Set<TEntity>().Any(set => set.Id == entity.Id);

            if(exists)
            {
                _context.Set<TEntity>().Update(entity);
            }
            else
            {
                _context.Set<TEntity>().Add(entity);
            }

            return await _context.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteByIdAsync(TEntity entity)
        {
            bool exists = _context.Set<TEntity>().Any(set => set.Id == entity.Id);

            if(exists)
            {
                _context.Set<TEntity>().Remove(entity);

                return await _context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }
        #endregion
    }
}
