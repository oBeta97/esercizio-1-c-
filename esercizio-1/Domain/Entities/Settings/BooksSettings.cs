namespace esercizio_1.Entities.Settings
{
    public class BooksSettings
    {
        public int PerPage { get; set; } = 1;
        public BaseOrderSettings Order { get; set; }
    }
}