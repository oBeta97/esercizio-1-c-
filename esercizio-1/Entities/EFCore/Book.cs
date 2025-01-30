using System;
using System.Collections.Generic;

namespace esercizio_1.Entities.EFCore;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; }

    public int? AuthorId { get; set; }

    public int? GenreId { get; set; }

    public int? PublicationYear { get; set; }

    public bool? IsAvailable { get; set; }

    public virtual Author? Author { get; set; }

    public virtual Genre? Genre { get; set; }

    public Book(string title)
    {
        Title = title ?? throw new ArgumentNullException(nameof(title));
    }

}
