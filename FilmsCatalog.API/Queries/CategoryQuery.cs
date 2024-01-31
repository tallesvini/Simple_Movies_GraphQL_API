using FilmsCatalog.DataAccess.Repositories.Interfaces;
using FilmsCatalog.Types;
using GraphQL.Types;

namespace FilmsCatalog.API.Queries
{
	public class CategoryQuery : ObjectGraphType
	{
        public CategoryQuery(ICategoryRepository categoryRepository)
        {
            Field<ListGraphType<CategoryType>>(
                "categories",
                resolve: context => categoryRepository.GetAsync());

            Field<CategoryType>(
                "category",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    int idMovie = context.GetArgument<int>("id");
                    return categoryRepository.GetByIdAsync(x => x.Id == idMovie);
                });
		}
    }
}
