using System.Linq.Expressions;
using FilmsCatalog.DataAccess.Repositories.Interfaces;
using FilmsCatalog.Database;
using Microsoft.EntityFrameworkCore;

namespace FilmsCatalog.DataAccess.Repositories
{
	public class AbstractRepository<TEntity> : IAbstractRepository<TEntity> where TEntity : class
	{
		private readonly FilmsCatalogContext _context;

		public AbstractRepository(FilmsCatalogContext context)
		{
			_context = context;
		}
		public IQueryable<TEntity> GetAsync()
		{
			return _context.Set<TEntity>();
		}

		public async Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
		}

		public async Task<TEntity> AddAsync(TEntity entity)
		{
			_context.Set<TEntity>().Add(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<TEntity> UpdateAsync(TEntity entity)
		{
			var entityId = typeof(TEntity).GetProperty("Id")?.GetValue(entity);
			var existingEntity = _context.Set<TEntity>().Find(entityId);

			if (existingEntity != null)
			{
				_context.Entry(existingEntity).CurrentValues.SetValues(entity);
				await _context.SaveChangesAsync();
			}

			return entity;
		}

		public TEntity DeleteAsync(TEntity entity)
		{
			var entityId = typeof(TEntity).GetProperty("Id")?.GetValue(entity);
			var existingEntity = _context.Set<TEntity>().Find(entityId);

			if (existingEntity != null)
			{
				_context.Set<TEntity>().Remove(existingEntity);
				_context.SaveChangesAsync();
			}

			return entity;
		}
	}
}
