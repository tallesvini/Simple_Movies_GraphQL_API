using FilmsCatalog.DataAccess.Repositories.Interfaces;
using FilmsCatalog.Database.Entities;
using FilmsCatalog.Types;
using GraphQL.Types;

namespace FilmsCatalog.API.Mutations
{
	public class CategoryMutation : ObjectGraphType
	{
        public CategoryMutation(ICategoryRepository categoryRepository)
        {
			Field<CategoryType>(
                "addCategory",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CategoryInputType>> { Name = "category" }),
                resolve: context => categoryRepository.AddAsync(context.GetArgument<Category>("category")));

			Field<CategoryType>(
				"updateCategory",
				arguments: new QueryArguments(new QueryArgument<CategoryUpdateType> { Name = "category" }),
				resolve: context => categoryRepository.UpdateAsync(context.GetArgument<Category>("category")));

			Field<CategoryType>(
				"deleteCategory",
				arguments: new QueryArguments(new QueryArgument<CategoryDeleteType> { Name = "category" }),
				resolve: context => categoryRepository.DeleteAsync(context.GetArgument<Category>("category")));
		}
	}
}
