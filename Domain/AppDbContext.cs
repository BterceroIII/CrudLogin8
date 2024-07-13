using Microsoft.EntityFrameworkCore;
using Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }


        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(tb =>
            {
                tb.HasKey(col => col.IdUsuario);
                tb.Property(col => col.IdUsuario)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

                tb.Property(col => col.Nombre)
                .HasMaxLength(50);
                tb.Property(col => col.Apellido)
                .HasMaxLength(50);
                tb.Property(col => col.Correo)
                .HasMaxLength(50);
                tb.Property(col => col.Clave)
                .HasMaxLength(50);

            });
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
        }



    }
}
