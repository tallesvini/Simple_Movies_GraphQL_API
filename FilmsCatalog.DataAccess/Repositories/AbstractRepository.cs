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
		public async Task<IList<TEntity>> GetAsync()
		{
			var test = await _context.Set<TEntity>().AsNoTracking().ToListAsync();
			return test;
		}

		public async Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return await _context.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();
		}

		public async Task<TEntity> AddAsync(TEntity entity)
		{
			_context.Set<TEntity>().Add(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<TEntity> UpdateAsync(TEntity entity)
		{
			_context.Entry(entity).State = EntityState.Modified;
			_context.Set<TEntity>().Update(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public TEntity DeleteAsync(TEntity entity)
		{
			_context.Set<TEntity>().Remove(entity);
			_context.SaveChangesAsync();
			return entity;
		}
	}
}
