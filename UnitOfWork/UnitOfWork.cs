using DataAccessArchitecture.Entity;
using DataAccessArchitecture.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessArchitecture.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork 
	{
		private readonly DbContext _dbContext;
		private readonly Dictionary<Type, object> _repositories;


		public UnitOfWork(DbContext dbContext)
		{
			_dbContext = dbContext;
			_repositories = new Dictionary<Type, object>();
		}

		public IRepository<TEntity> GetRepository<TEntity>() where TEntity: class, IEntity
		{
			if (_repositories.TryGetValue(typeof(TEntity), out var repository))
			{
				repository = new Repository<TEntity>(_dbContext);
				_repositories[typeof(TEntity)] = repository;
			}
			return (IRepository<TEntity>)repository;
		}

		public async Task SaveChangesAsync()
		{
			await _dbContext.SaveChangesAsync();
		}
	}
}
