using DataAccessArchitecture.Entity;
using DataAccessArchitecture.Repository;
using System.Threading.Tasks;

namespace DataAccessArchitecture.UnitOfWork
{
	public interface IUnitOfWork
	{
		IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity;

		Task SaveChangesAsync();
	}
}
