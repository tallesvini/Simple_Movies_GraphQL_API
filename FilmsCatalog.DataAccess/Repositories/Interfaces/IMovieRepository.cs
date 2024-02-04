using FilmsCatalog.Database.Entities;

namespace FilmsCatalog.DataAccess.Repositories.Interfaces
{
	public interface IMovieRepository : IAbstractRepository<Movie>	
	{
		IList<Movie> GetAllForCategories(int? categoryId);
	}
}
