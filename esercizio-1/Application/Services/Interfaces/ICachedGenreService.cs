namespace esercizio_1.Interfaces
{
    // Per evitare di blindare GenreService alla cache andiamo a creare un layer di caching tramite questa interfaccia
    // così facendo i vari service che andremo a creare avranno la possibilità di scegliere se utilizzare il servizio di caching o no
    public interface ICachedGenreService : IGenreService
    {
        
    }
}