using FilmsCatalog.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmsCatalog.Database.Mapping
{
	public class MovieMap : IEntityTypeConfiguration<Movie>
	{
		public void Configure(EntityTypeBuilder<Movie> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedOnAdd();
			builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
			builder.Property(x => x.Description).IsRequired().HasMaxLength(512);
			builder.Property(x => x.ReleasedYear);
			builder.Property(x => x.Director).IsRequired();
			builder.Property(x => x.Cast);
			builder.Property(x => x.Rating);
			builder.Property(x => x.Review);
			builder.Property(x => x.Duration).IsRequired();
			builder.Property(x => x.Trailer).IsRequired();
			builder.Property(x => x.Poster);
			builder.Property(x => x.CountryOfOrigin);
			builder.Property(x => x.Language);
			builder.Property(x => x.Keywords);
			builder.Property(x => x.DateAdded);
		}
	}
}
