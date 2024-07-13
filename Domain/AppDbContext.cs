
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models.Crud;
using Models.Login;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // propiedades de las columnas
            modelBuilder.Entity<Empleado>(tb =>
            {
                tb.HasKey(col => col.IdEmpleado);

                tb.Property(col => col.IdEmpleado)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

                tb.Property(col => col.Nombre).HasMaxLength(20);
                tb.Property(col => col.Apellido).HasMaxLength(20);
                tb.Property(col => col.Correo).HasMaxLength(50);
            });

            // creacion de la tabla
            modelBuilder.Entity<Empleado>().ToTable("Empleado");

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








