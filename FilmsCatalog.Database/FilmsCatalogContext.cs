using FilmsCatalog.Database.Entities;
using FilmsCatalog.Database.Mapping;
using Microsoft.EntityFrameworkCore;

namespace FilmsCatalog.Database
{
	public class FilmsCatalogContext : DbContext
	{
		public FilmsCatalogContext(DbContextOptions<FilmsCatalogContext> options) : base(options) { }

		public DbSet<Movie> Movies { get; set; }
		public DbSet<Category> Categories { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new MovieMap());
			modelBuilder.ApplyConfiguration(new CategoryMap());
			base.OnModelCreating(modelBuilder);
		}
	}
}
