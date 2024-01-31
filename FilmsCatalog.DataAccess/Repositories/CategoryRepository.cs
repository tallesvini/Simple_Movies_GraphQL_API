using FilmsCatalog.DataAccess.Repositories.Interfaces;
using FilmsCatalog.Database;
using FilmsCatalog.Database.Entities;

namespace FilmsCatalog.DataAccess.Repositories
{
	public class CategoryRepository : AbstractRepository<Category>, ICategoryRepository
	{
		public CategoryRepository(FilmsCatalogContext dbContext) : base(dbContext) { }
	}
}
