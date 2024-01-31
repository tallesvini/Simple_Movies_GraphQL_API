using GraphQL.Types;

namespace FilmsCatalog.Types
{
	public class CategoryInputType : InputObjectGraphType
	{
        public CategoryInputType()
        {
            Name = "CategoryInput";
            Field<IntGraphType>("id");
            Field<NonNullGraphType<StringGraphType>>("name");
        }
    }
}
