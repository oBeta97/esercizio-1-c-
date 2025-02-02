using System;
using System.Collections.Generic;

namespace esercizio_1.Entities.EFCore;

public partial class Book(string title)
{
    public int Id { get; set; }

    public string Title { get; set; } = title ?? throw new ArgumentNullException(nameof(title));

    public int? AuthorId { get; set; }

    public int? GenreId { get; set; }

    public int? PublicationYear { get; set; }

    public bool? IsAvailable { get; set; }

    public virtual Author? Author { get; set; }

    public virtual Genre? Genre { get; set; }
}
