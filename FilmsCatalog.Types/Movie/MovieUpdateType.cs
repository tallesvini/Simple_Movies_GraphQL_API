using FilmsCatalog.Database.Entities;
using GraphQL.Types;

namespace FilmsCatalog.Types
{
	public class MovieUpdateType : InputObjectGraphType<Movie>
	{
        public MovieUpdateType()
        {
			Name = "MovieUpdate";
			Field<NonNullGraphType<IntGraphType>>("id");
			Field<StringGraphType>("name");
			Field<StringGraphType>("description");
			Field<StringGraphType>("releasedYear");
			Field<IntGraphType>("categoryId");
		}
    }
}
