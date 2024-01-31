using GraphQL.Types;
using FilmsCatalog.DataAccess.Repositories.Interfaces;
using FilmsCatalog.Database.Entities;

namespace FilmsCatalog.Types
{
	public class CategoryType : ObjectGraphType<Category>
	{
        public CategoryType(IMovieRepository movieRepository)
        {
            Field(x => x.Id);
            Field(x => x.Name);
			Field<ListGraphType<MovieType>>("movies",
				resolve: context => movieRepository.GetAllForCategories(context.Source.Id));
		}
    }
}
