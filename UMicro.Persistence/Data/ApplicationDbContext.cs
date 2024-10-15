using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Domain.Modelo;

namespace UMicro.Persistence.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libros> Libros { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Verifica si el contexto ya ha sido configurado
            if (!optionsBuilder.IsConfigured)
            {
                // Configura la cadena de conexión y el ensamblado de migraciones
                optionsBuilder.UseSqlServer("SERVER=Lexth;database=ParcialDos;Trusted_Connection=true;TrustServerCertificate=True;",
                    b => b.MigrationsAssembly("UMicro.Persistence")); // Especifica el ensamblado de migraciones
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Autor>(entity => entity.ToTable("Autores"));
            modelBuilder.Entity<Libros>(entity => entity.ToTable("Libros"));
            modelBuilder.Entity<Editorial>(entity => entity.ToTable("Editoriales"));
        }
    }
}
