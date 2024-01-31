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
            Field<ListGraphType<CategoryType>>("category",
                resolve: context => categoryRepository.GetByIdAsync(x => x.Id == context.Source.CategoryId));
		}
    }
}
