using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SelfFit.Application;
using SelfFit.Application.Exceptions;
using SelfFit.Domain;

namespace SelfFit.Persistence
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly SelfFitDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(SelfFitDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public IQueryable<TEntity> Query()
        {
            return _dbSet.AsQueryable();
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }
        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }
        public async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync();
        }

        public Task<bool> Exist(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).AnyAsync();
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                return false;
            }

            await _dbSet.AddAsync(entity);

            return (await _context.SaveChangesAsync()) > 0;
        }
        public async Task<bool> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);

            return (await _context.SaveChangesAsync()) > 0;
        }
        public async Task<bool> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                return false;
            }

            _dbSet.Update(entity);

            return (await _context.SaveChangesAsync()) > 0;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var entityToDelete = _dbSet.FirstOrDefault(e => e.Id == id);
            if (entityToDelete == null)
            {
                throw new NotFoundException($"There is no entity of type {typeof(TEntity)} with id={id}");
            }

            _dbSet.Remove(entityToDelete);

            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
