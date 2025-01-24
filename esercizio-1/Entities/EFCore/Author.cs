using System;
using System.Collections.Generic;

namespace esercizio_1.Entities.EFCore;

public partial class Author
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Country { get; set; }

    public virtual ICollection<Book> Books { get; set; } = [];

    public Author(string name)
    {
        this.Name = name;
    }

}
