using GraphQL.Types;

namespace FilmsCatalog.Types
{
	public class CategoryDeleteType : InputObjectGraphType
	{
		public CategoryDeleteType()
		{
			Name = "CategoryDelete";
			Field<NonNullGraphType<IntGraphType>>("id");
		}
	}
}
