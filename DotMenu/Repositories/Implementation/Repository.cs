using System;
using System.Linq;
using System.Threading.Tasks;
using DotMenu.Repositories.Context;

namespace DotMenu.Repositories.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly DotmenuDBContext _dotmenuDbContext;

        protected Repository(DotmenuDBContext dotmenuDbContext)
        {
            _dotmenuDbContext = dotmenuDbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return _dotmenuDbContext.Set<TEntity>();
            }
            catch (Exception e)
            {
                throw new Exception($"Couldn't retrieve entities: {e.Message}");
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }
            
            try
            {
                await _dotmenuDbContext.AddAsync(entity);
                await _dotmenuDbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception e)
            {
                throw new Exception($"Couldn't retrieve entities: {e.Message}");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }
            
            try
            {
                _dotmenuDbContext.Update(entity);
                await _dotmenuDbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception e)
            {
                throw new Exception($"Couldn't retrieve entities: {e.Message}");
            }
        }
    }
}