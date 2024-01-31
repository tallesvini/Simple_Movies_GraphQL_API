using FilmsCatalog.API.Mutations;
using FilmsCatalog.API.Queries;
using FilmsCatalog.API.Schemas;
using FilmsCatalog.DataAccess.Repositories;
using FilmsCatalog.DataAccess.Repositories.Interfaces;
using FilmsCatalog.Database;
using FilmsCatalog.Types;
using GraphQL;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IMovieRepository, MovieRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();

string connectionString = builder.Configuration.GetConnectionString("FilmsCatalogDB");

builder.Services.AddDbContext<FilmsCatalogContext>(options =>
	options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<IDocumentExecuter, DocumentExecuter>();
builder.Services.AddScoped<MovieQuery>();
builder.Services.AddScoped<CategoryQuery>();
builder.Services.AddScoped<RootQuery>();

builder.Services.AddScoped<MovieType>();
builder.Services.AddScoped<MovieInputType>();
builder.Services.AddScoped<MovieUpdateType>();
builder.Services.AddScoped<MovieDeleteType>();

builder.Services.AddScoped<CategoryType>();
builder.Services.AddScoped<CategoryInputType>();
builder.Services.AddScoped<CategoryUpdateType>();
builder.Services.AddScoped<CategoryDeleteType>();

builder.Services.AddScoped<CategoryMutation>();
builder.Services.AddScoped<MovieMutation>();
builder.Services.AddScoped<RootMutation>();

var sp = builder.Services.BuildServiceProvider();
builder.Services.AddSingleton<ISchema>(new FilmsCatalogSchema(new FuncDependencyResolver(type => sp.GetService(type))));

var app = builder.Build();

app.UseGraphiQl();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
