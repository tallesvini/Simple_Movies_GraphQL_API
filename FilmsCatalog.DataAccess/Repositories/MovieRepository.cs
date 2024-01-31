using FilmsCatalog.DataAccess.Repositories.Interfaces;
using FilmsCatalog.Database;
using FilmsCatalog.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmsCatalog.DataAccess.Repositories
{
	public class MovieRepository : AbstractRepository<Movie>, IMovieRepository
	{
		private readonly FilmsCatalogContext _dbContext;

		public MovieRepository(FilmsCatalogContext dbcontext) : base(dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<Movie>> GetAllForCategories(int categoryId)
        {
            return await _dbContext.Movies.Where(x => x.CategoryId == categoryId).ToListAsync();
        }
    }
}
