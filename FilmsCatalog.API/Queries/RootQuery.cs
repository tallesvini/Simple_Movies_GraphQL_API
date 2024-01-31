using GraphQL.Types;

namespace FilmsCatalog.API.Queries
{
	public class RootQuery : ObjectGraphType
	{
        public RootQuery()
        {
			Field<MovieQuery>(
				"movieQuery",
				resolve: context => new { });

			Field<CategoryQuery>(
				"categoryQuery",
				resolve: context => new { });
		}
    }
}
