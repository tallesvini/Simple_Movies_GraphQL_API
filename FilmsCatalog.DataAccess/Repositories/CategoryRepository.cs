using FilmsCatalog.DataAccess.Repositories.Interfaces;
using FilmsCatalog.Database;
using FilmsCatalog.Database.Entities;

namespace FilmsCatalog.DataAccess.Repositories
{
	public class CategoryRepository : AbstractRepository<Category>, ICategoryRepository
	{
		private readonly FilmsCatalogContext _dbContext;

		public CategoryRepository(FilmsCatalogContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}

		public Category GetAllForMovies(int? categoryId)
		{
			return _dbContext.Categories.FirstOrDefault(x => x.Id == categoryId);
		}
	}
}
