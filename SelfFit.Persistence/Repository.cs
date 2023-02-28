using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SelfFit.Application;
using SelfFit.Domain;

namespace SelfFit.Persistence
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly SelfFitDbContext _context;
        public Repository(SelfFitDbContext context)
        {
            _context = context;
        }
        public IQueryable<TEntity> Query()
        {
            return _context.Set<TEntity>().AsQueryable();
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }
        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }
        public async Task<int> CountAsync()
        {
            return await _context.Set<TEntity>().CountAsync();
        }

        public Task<bool> Exist(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).AnyAsync();
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                return false;
            }

            await _context.Set<TEntity>().AddAsync(entity);

            return (await _context.SaveChangesAsync()) > 0;
        }
        public async Task<bool> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                return false;
            }

            _context.Set<TEntity>().Update(entity);

            return (await _context.SaveChangesAsync()) > 0;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var entityToDelete = _context.Set<TEntity>().FirstOrDefault(e => e.Id == id);
            if (entityToDelete == null)
            {
                return false;
            }

            _context.Set<TEntity>().Remove(entityToDelete);

            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
