using FilmsCatalog.API.Mutations;
using FilmsCatalog.API.Queries;
using GraphQL;

namespace FilmsCatalog.API.Schemas
{
	public class FilmsCatalogSchema : GraphQL.Types.Schema
	{
        public FilmsCatalogSchema(IDependencyResolver resolver) : base(resolver)
        {
			Query = resolver.Resolve<RootQuery>();
			Mutation = resolver.Resolve<RootMutation>();
		}
    }
}
