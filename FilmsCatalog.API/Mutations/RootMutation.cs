using GraphQL.Types;

namespace FilmsCatalog.API.Mutations
{
	public class RootMutation : ObjectGraphType
	{
		public RootMutation()
		{
			Field<CategoryMutation>(
				"categoryMutation", 
				resolve: context => new { });

			Field<MovieMutation>(
				"movieMutation",
				resolve: context => new { }); 
		}
	}
}
