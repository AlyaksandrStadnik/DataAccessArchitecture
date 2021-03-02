using DataAccessArchitecture.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccessArchitecture.Repository
{
	public interface IRepository<TEntity> where TEntity: class, IEntity
	{
		void Add(TEntity entity);

		void AddRange(IEnumerable<TEntity> entities);

		Task<IEnumerable<TEntity>> GetAllAsync();

		Task<TEntity> GetByIdAsync(int id);

		Task<TEntity> GetByPredicateAsync(Expression<Func<TEntity, bool>> predicate);

		void Update(TEntity entity);

		void Remove(TEntity entity);

		void RemoveRange(IEnumerable<TEntity> entities);
	}
}
