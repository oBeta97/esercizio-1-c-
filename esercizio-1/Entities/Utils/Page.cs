using Serilog;

namespace esercizio_1.Entities.Utils
{
    public class Page<T>(List<T> _items, long _totItems, int _pageLimit, int _pageIndex)
    {
        public List<T> Items { get; set; } = _items;
        public int PageNumber { get; set; } = _pageIndex;
        public int PageSize { get; set; } = _pageLimit;
        public long TotalItems { get; set; } = _totItems;
        public int TotalPages { get; set; } = (int)_totItems / _pageLimit + 1;
        public bool HasPreviousPage => PageNumber >= 1;
        public bool HasNextPage => PageNumber < TotalPages;
    }
}