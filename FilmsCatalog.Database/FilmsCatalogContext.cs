using FilmsCatalog.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmsCatalog.Database
{
	public class FilmsCatalogContext : DbContext
	{
		public FilmsCatalogContext(DbContextOptions<FilmsCatalogContext> options) : base(options) { }

		public DbSet<Movie> Movies { get; set; }
		public DbSet<Category> Categories { get; set; }
    }
}
