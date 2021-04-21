using DataAccessArchitecture.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccessArchitecture.Repository
{
	public class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
	{
		protected readonly DbContext _context;

		private readonly DbSet<TEntity> _aggregate;

		public EntityRepository(DbContext context)
		{
			_context = context;
			_aggregate = _context.Set<TEntity>();
		}

		public void Add(TEntity entity)
		{
			_aggregate.Add(entity);
		}

		public void AddRange(IEnumerable<TEntity> entities)
		{
			_aggregate.AddRange(entities);
		}

		public async Task<TEntity> GetByIdAsync(int id) 
		{
			return await GetQuery().SingleOrDefaultAsync(e => e.Id == id);
		}

		public async Task<TEntity> GetByPredicateAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return await GetQuery().SingleOrDefaultAsync(predicate);
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			return await GetQuery().ToListAsync();
		}

		public void Remove(TEntity entity)
		{
			_aggregate.Remove(entity);
		}

		public void RemoveRange(IEnumerable<TEntity> entities)
		{
			_aggregate.RemoveRange(entities);
		}

		public void Update(TEntity entity)
		{
			_aggregate.Update(entity);
		}

		protected virtual IQueryable<TEntity> GetQuery()
		{
			return _aggregate;
		}
	}
}
