using System.ComponentModel.DataAnnotations;
using esercizio_1.Entities.EFCore;

namespace esercizio_1.Payloads
{
    public class BookDTO
    {
        // Aggiunti i DataAnnotation per indicare i requisiti dei DTO in entrata
        [Required]
        public string Title { get; set; }

        [
            Required,
            Range(0, int.MaxValue, ErrorMessage = "AuthorId must be positive")
        ]
        public int? AuthorId { get; set; }

        [
            Required,
            Range(0, int.MaxValue, ErrorMessage = "GenreId must be positive")
        ]
        public int? GenreId { get; set; }

        [
            Required,
            Range(1800, int.MaxValue, ErrorMessage = "PublicationYear must be from 1800 to infinite")
        ]
        public int? PublicationYear { get; set; }
        public bool IsAvailable { get; set; } = false;

        public BookDTO(string title)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
        }


        // Aggiunto il metodo toBook così da poter avere l'oggetto da far gestire a EFCore
        public Book ToBook()
        {
            return new Book(Title)
            {
                AuthorId = AuthorId,
                GenreId = GenreId,
                PublicationYear = PublicationYear,
                IsAvailable = IsAvailable
            };

            
        }
    }

}