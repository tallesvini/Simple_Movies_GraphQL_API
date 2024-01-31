namespace FilmsCatalog.Database.Entities
{
	public class Movie
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime ReleasedYear { get; set; } = DateTime.Now;

        public int? CategoryId { get; set; }
		public Category? Category { get; set; }
    }
}
