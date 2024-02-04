using GraphQL.Types;

namespace FilmsCatalog.Types
{
    public class MovieInputType : InputObjectGraphType
    {
        public MovieInputType()
        {
            Name = "MovieInput";
			Field<NonNullGraphType<StringGraphType>>("name");
			Field<NonNullGraphType<StringGraphType>>("description");
			Field<StringGraphType>("releasedYear");
			Field<NonNullGraphType<StringGraphType>>("director");
			Field<StringGraphType>("cast");
			Field<StringGraphType>("rating");
			Field<StringGraphType>("review");
			Field<NonNullGraphType<StringGraphType>>("duration");
			Field<NonNullGraphType<StringGraphType>>("trailer");
			Field<StringGraphType>("poster");
			Field<StringGraphType>("countryOfOrigin");
			Field<StringGraphType>("language");
			Field<StringGraphType>("keywords");
			Field<IntGraphType>("categoryId");
		}
    }
}
