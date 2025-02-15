using Microsoft.EntityFrameworkCore;

namespace esercizio_1.Entities.EFCore;

// Classe creata a partire dal comando dotnet:
// dotnet ef dbcontext scaffold "Server=localhost;Port=5432;Database=librarydb;Username=postgres;Password=1234;" Npgsql.EntityFrameworkCore.PostgreSQL -o Entities/EFCore/

public partial class LibrarydbContext(DbContextOptions<LibrarydbContext> options) : DbContext(options)
{
    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }


    // !!! NB !!! -> Dato che si sta utilizzando il addDbContextPoll questo override va in conflitto
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //     // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //     => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=librarydb;Username=postgres;Password=1234;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.ToTable("authors");

            entity.HasKey(e => e.Id).HasName("authors_pkey");
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Country)
                .HasColumnName("country")
                .HasMaxLength(100);

            entity.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(255);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("books");

            entity.HasKey(e => e.Id).HasName("books_pkey");
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.AuthorId).HasColumnName("author_id");

            entity.Property(e => e.GenreId).HasColumnName("genre_id");

            entity.Property(e => e.IsAvailable)
                .HasDefaultValue(true)
                .HasColumnName("is_available");

            entity.Property(e => e.PublicationYear).HasColumnName("publication_year");

            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("books_author_id_fkey");

            entity.HasOne(d => d.Genre).WithMany(p => p.Books)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("books_genre_id_fkey");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable("genres");

            entity.HasKey(e => e.Id).HasName("genres_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
