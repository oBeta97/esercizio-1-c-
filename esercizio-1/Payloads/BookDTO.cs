namespace esercizio_1.Payloads
{
    public class BookDTO
    {
        public string Title { get; set; }

        public int? AuthorId { get; set; }

        public int? GenreId { get; set; }

        public int? PublicationYear { get; set; }

        public bool? IsAvailable { get; set; }

        public BookDTO(string title)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
        }
    }

}