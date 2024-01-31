using FilmsCatalog.Database.Entities;

namespace FilmsCatalog.DataAccess.Repositories.Interfaces
{
	public interface IMovieRepository : IAbstractRepository<Movie>	
	{
		Task<IEnumerable<Movie>> GetAllForCategories(int categoryId);
	}
}
