using System.Linq.Expressions;

namespace FilmsCatalog.DataAccess.Repositories.Interfaces
{
	public interface IAbstractRepository<TEntity> 
		where TEntity : class
	{
		Task<IList<TEntity>> GetAsync();
		Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> predicate);
		Task<TEntity> AddAsync(TEntity entity);
		Task<TEntity> UpdateAsync(TEntity entity);
		TEntity DeleteAsync(TEntity entity);
	}
}
