using FilmsCatalog.DataAccess.Repositories.Interfaces;
using FilmsCatalog.Database.Entities;
using FilmsCatalog.Types;
using GraphQL.Types;

namespace FilmsCatalog.API.Mutations
{
	public class MovieMutation : ObjectGraphType
	{
		public MovieMutation(IMovieRepository movieRepository)
		{
			Field<MovieType>(
				"addMovie",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<MovieInputType>> { Name = "movie" }),
				resolve: context => movieRepository.AddAsync(context.GetArgument<Movie>("movie")));

			Field<MovieType>(
				"updateMovie",
				arguments: new QueryArguments(new QueryArgument<MovieUpdateType> { Name = "movie" }),
				resolve: context => movieRepository.UpdateAsync(context.GetArgument<Movie>("movie")));

			Field<MovieType>(
				"deleteMovie",
				arguments: new QueryArguments(new QueryArgument<MovieDeleteType> { Name = "movie" }),
				resolve: context => movieRepository.DeleteAsync(context.GetArgument<Movie>("movie")));
		}
	}
}
