using FilmsCatalog.DataAccess.Repositories.Interfaces;
using FilmsCatalog.Database.Entities;
using GraphQL.Types;

namespace FilmsCatalog.Types
{
	public class MovieType : ObjectGraphType<Movie>
	{
		public MovieType(ICategoryRepository categoryRepository)
		{
			Field(x => x.Id);
			Field(x => x.Name);
			Field(x => x.Description);
			Field(x => x.ReleasedYear);
			Field(x => x.Director);
			Field(x => x.Cast);
			Field(x => x.Rating);
			Field(x => x.Review);
			Field(x => x.Duration);
			Field(x => x.Trailer);
			Field(x => x.Poster);
			Field(x => x.CountryOfOrigin);
			Field(x => x.Language);
			Field(x => x.Keywords);
			Field(x => x.DateAdded);
			Field<CategoryType>("category",
				resolve: context => categoryRepository.GetAllForMovies(context.Source.CategoryId));
		}
	}
}

