using GraphQL.Types;

namespace FilmsCatalog.Types
{
    public class MovieDeleteType : InputObjectGraphType
    {
        public MovieDeleteType()
        {
            Name = "MovieDelete";
            Field<NonNullGraphType<IntGraphType>>("id");
        }
    }
}
