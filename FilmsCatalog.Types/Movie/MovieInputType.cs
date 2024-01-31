using GraphQL.Types;

namespace FilmsCatalog.Types
{
    public class MovieInputType : InputObjectGraphType
    {
        public MovieInputType()
        {
            Name = "MovieInput";
            Field<IntGraphType>("id");
            Field<StringGraphType>("name");
            Field<StringGraphType>("description");
            Field<IntGraphType>("categoryId");
        }
    }
}
