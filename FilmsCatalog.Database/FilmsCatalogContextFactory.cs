﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FilmsCatalog.Database
{
	public class FilmsCatalogContextFactory : IDesignTimeDbContextFactory<FilmsCatalogContext>
	{
		public FilmsCatalogContext CreateDbContext(string[] args)
		{
			IConfigurationRoot configuration = new ConfigurationBuilder()
				.AddJsonFile("caminho_arquivo_appsettings.json")
				.Build();

			var builder = new DbContextOptionsBuilder<FilmsCatalogContext>();
			var connectionString = configuration.GetConnectionString("FilmsCatalogDB");

			builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

			return new FilmsCatalogContext(builder.Options);
		}
	}
}
