using System;
using System.Collections.Generic;

namespace esercizio_1.Entities.EFCore;

public partial class Genre
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();


    public Genre(string name)
    {
        this.Name = name;
    }

}
