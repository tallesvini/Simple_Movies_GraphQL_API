using FilmsCatalog.DataAccess.Repositories;
using FilmsCatalog.DataAccess.Repositories.Interfaces;
using FilmsCatalog.Types;
using GraphQL.Types;

namespace FilmsCatalog.API.Queries
{
	public class MovieQuery : ObjectGraphType
	{
        public MovieQuery(IMovieRepository movieRepository)
        {
            Field<ListGraphType<MovieType>>("movies",
                resolve: context => movieRepository.GetAsync());

			Field<MovieType>(
				"movie",
				arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
				resolve: context =>
				{
					int idMovie = context.GetArgument<int>("id");
					return movieRepository.GetByIdAsync(x => x.Id == IdCategory);
				});
		}
    }
}
