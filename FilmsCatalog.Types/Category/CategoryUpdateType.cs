using FilmsCatalog.Database.Entities;
using GraphQL.Types;

namespace FilmsCatalog.Types
{
    public class CategoryUpdateType : InputObjectGraphType<Category>
    {
        public CategoryUpdateType()
        {
            Name = "CategoryUpdate";
            Field<NonNullGraphType<IntGraphType>>("id");
            Field<StringGraphType>("name");
        }
    }
}
