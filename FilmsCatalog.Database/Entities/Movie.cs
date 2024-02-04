namespace FilmsCatalog.Database.Entities
{
	public class Movie
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string ReleasedYear { get; set; }
        public string Director { get; set; }
        public string Cast { get; set; }
        public string Rating { get; set; }
        public string Review { get; set; }
        public string Duration { get; set; }
        public string Trailer { get; set; }
        public string Poster { get; set; }
        public string CountryOfOrigin { get; set; }
        public string Language { get; set; }
        public string Keywords { get; set; }
        public DateTime DateAdded { get; set; }

        public int? CategoryId { get; set; }
		public Category? Category { get; set; }
    }
}
