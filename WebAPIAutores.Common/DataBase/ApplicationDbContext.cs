using Microsoft.EntityFrameworkCore;
using WebAPIAutores.Common.Entities;

namespace WebAPIAutores.Common.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<AutorLibro>()
            //    .HasKey(al => new { al.AutorId, al.LibroId });

        }

        public DbSet<Autor> Autores { get; set; }
        //public DbSet<Libro> Libros { get; set; }
        //public DbSet<Comentario> Comentarios { get; set; }
        //public DbSet<AutorLibro> AutoresLibros { get; set; }
    }
}
