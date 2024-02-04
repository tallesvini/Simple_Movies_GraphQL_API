using FilmsCatalog.DataAccess.Repositories.Interfaces;
using FilmsCatalog.Database;
using FilmsCatalog.Database.Entities;

namespace FilmsCatalog.DataAccess.Repositories
{
	public class MovieRepository : AbstractRepository<Movie>, IMovieRepository
	{
		private readonly FilmsCatalogContext _dbContext;

		public MovieRepository(FilmsCatalogContext dbcontext) : base(dbcontext)
        {
            _dbContext = dbcontext;
        }

		public IList<Movie> GetAllForCategories(int? categoryId)
		{
			return _dbContext.Movies.Where(x => x.CategoryId == categoryId).ToList();
		}
	}
}
