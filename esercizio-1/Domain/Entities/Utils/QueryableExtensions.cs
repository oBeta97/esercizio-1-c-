
using Microsoft.EntityFrameworkCore;

namespace esercizio_1.Entities.Utils
{
    public static class QueryableExtensions
    {
        // SPIEGAZIONE!:
        //  Perché è un extension method?
        //  reso tale dalla clausola this IQueryable<T> source!
        //  In C#, quando un metodo è definito in una classe STATICA e ha il primo parametro preceduto da THIS,
        //  il compilatore permette di invocarne la logica in modo “esteso” su qualsiasi oggetto compatibile


        // this IQueryable<T> source significa che stai “agganciando” il metodo OrderByDynamic a qualsiasi oggetto di tipo IQueryable<T>.
        public static IQueryable<T> OrderByDynamic<T>(
            // Questa riga va a dire che questo è un extension method di IQueryable. Così da poterlo concatenare tipo: myQueryable.OrderByDynamic("MyProperty")
            this IQueryable<T> source,
            string propertyName,
            bool ascending = true
        )
        {
            // Se propertyName è null o vuoto, restituiamo la query così com’è (nessun ordinamento)
            if (string.IsNullOrEmpty(propertyName))
                return source;

            // EF.Property<object>:
            // Metodo di EFCore per mappare una stringa ad una colonna di una tabella.
            // Property<T> solitamente viene valorizzato con object perché non si sa il tipo di ritorno (se lo si sa meglio specificarlo)
            // ATTENZIONE! Non essendo tipizzato potrebbero nascere errori se in "propertyName" arriva sporcizia
            return ascending
                ? source.OrderBy(x => EF.Property<object>(x, propertyName))
                : source.OrderByDescending(x => EF.Property<object>(x, propertyName));
        }

    }
}