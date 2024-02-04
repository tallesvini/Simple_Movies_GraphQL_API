using FilmsCatalog.Database.Entities;

namespace FilmsCatalog.DataAccess.Repositories.Interfaces
{
	public interface ICategoryRepository : IAbstractRepository<Category>
	{
		Category GetAllForMovies(int? categoryId);
	}
}
