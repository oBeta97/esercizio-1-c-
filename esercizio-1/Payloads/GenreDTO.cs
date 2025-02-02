using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using esercizio_1.Entities;

namespace esercizio_1.Payloads
{
    public class GenreDTO(string name)
    {
        
    public string Name { get; set; } = name;

    public virtual ICollection<Book> Books { get; set; } = [];
    }
}