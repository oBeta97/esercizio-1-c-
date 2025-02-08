using System.Data;

namespace esercizio_1.Entities
{
    public class Book
    {
        public int Id { get; set; } // Identificativo unico del libro
        public string Title { get; set; } // Titolo del libro
        public int? AuthorId { get; set; } // ID dell'autore (nullable se non assegnato)
        public int? GenreId { get; set; } // ID del genere (nullable se non assegnato)
        public int? PublicationYear { get; set; } // Anno di pubblicazione (opzionale)
        public bool IsAvailable { get; set; } // Disponibilità del libro (true o false)

        public static Book FromDataRow(DataRow bookRow)
        {
            return new Book
            {
                Id = (int)bookRow["id"],
                Title = (string)bookRow["title"],
                AuthorId = bookRow["author_id"] != null ? (int)bookRow["author_id"] : null,
                GenreId = bookRow["genre_id"] != null ? (int)bookRow["genre_id"] : null,
                PublicationYear = bookRow["publication_year"] != null ? (int)bookRow["publication_year"] : null,
                IsAvailable = (bool)bookRow["is_available"]
            };
        }

    }
}