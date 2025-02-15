using System.Data;

namespace esercizio_1.Entities
{
    public class Author
    {
        public int Id { get; set; } // Identificativo unico
        public string Name { get; set; } // Nome dell'autore
        public string Country { get; set; } // Paese di origine

        public static Author FromDataRow(DataRow authorsRow)
        {

            return new Author
            {
                Id = (int)authorsRow["id"],
                Name = (string)authorsRow["name"],
                Country = (string)authorsRow["country"]
            };
        }

    }
}