using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NoAdsHere.Database.Repositories.Interfaces;

namespace NoAdsHere.Database.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DatabaseContext Context;

        public Repository(DatabaseContext context)
        {
            Context = context;
        }

        public TEntity Get(params object[] keyValues)
            => Context.Set<TEntity>().Find(keyValues);

        public async Task<TEntity> GetAsync(params object[] keyValues)
            => await Context.Set<TEntity>().FindAsync(keyValues).ConfigureAwait(false);

        public IEnumerable<TEntity> GetAll()
            => Context.Set<TEntity>().ToList();

        public async Task<IEnumerable<TEntity>> GetAllAsync()
            => await Context.Set<TEntity>().ToListAsync().ConfigureAwait(false);

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
            => Context.Set<TEntity>().Where(predicate);

        public void Add(TEntity entity)
            => Context.Set<TEntity>().Add(entity);

        public async Task AddAsync(TEntity entity)
            => await Context.Set<TEntity>().AddAsync(entity).ConfigureAwait(false);

        public void AddRange(IEnumerable<TEntity> entities)
            => Context.Set<TEntity>().AddRange(entities);

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
            => await Context.Set<TEntity>().AddRangeAsync(entities).ConfigureAwait(false);

        public void Remove(TEntity entity)
            => Context.Set<TEntity>().Remove(entity);

        public void RemoveRange(IEnumerable<TEntity> entities)
            => Context.Set<TEntity>().RemoveRange(entities);
    }
}