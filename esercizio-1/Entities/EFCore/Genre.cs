using System;
using System.Collections.Generic;

namespace esercizio_1.Entities.EFCore;

public partial class Genre(string name)
{
    public int Id { get; set; }

    public string Name { get; set; } = name;

    public virtual ICollection<Book> Books { get; set; } = [];
}
