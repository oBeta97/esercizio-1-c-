namespace esercizio_1.Entities.Utils
{
    public class Page<T>
    {
        public List<T> Items { get; set; } = [];
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public long TotalItems { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage => PageNumber >= 1;
        public bool HasNextPage => PageNumber < TotalPages;
    }
}