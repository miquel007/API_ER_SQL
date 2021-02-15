using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Models;

namespace WebApplication1.Models
{
    public partial class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Cajero> Productos { get; set; }
        public virtual DbSet<Producto> Cajeros { get; set; }
        public virtual DbSet<Maquina> Maquinas_Registradoras { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Cajero>().HasKey(p => p.Codigo);
           modelBuilder.Entity<Cajero>( entity =>
            {
                entity.ToTable("Cajeros");
                entity.Property(p => p.Codigo).HasColumnName("codigo");
                entity.Property(p => p.nomApels)
                    .HasColumnName("nomApels")
                    .HasMaxLength(255)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<Maquina>().HasKey(p => p.Codigo);
            modelBuilder.Entity<Maquina>(entity =>
            {
                entity.ToTable("Maquinas_Registradoras");
                entity.Property(p => p.Codigo).HasColumnName("codigo");
                entity.Property(p => p.piso).HasColumnName("piso");
            });

            modelBuilder.Entity<Producto>().HasKey(p => p.Codigo);
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Productos");
                entity.Property(p => p.Codigo).HasColumnName("codigo");
                entity.Property(p => p.nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(p => p.precio).HasColumnName("precio");
            });


            modelBuilder.Entity<Venta>().HasKey(s => s.Cajero);
            modelBuilder.Entity<Venta>().HasKey(s => s.Producto);
            modelBuilder.Entity<Venta>().HasKey(s => s.Maquina);
            modelBuilder.Entity<Venta>(entity =>
            {
                entity.ToTable("Venta");
                entity.Property(s => s.Cajero).HasColumnName("cajero");
                entity.Property(s => s.Producto).HasColumnName("producto");
                entity.Property(s => s.Maquina).HasColumnName("maquina");
                entity.HasOne(s => s.Maquinas)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(s => s.Maquina)
                    .HasConstraintName("maquina");
                entity.HasOne(s => s.Productos)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(s => s.Producto)
                    .HasConstraintName("producto");
                entity.HasOne(s => s.Cajeros)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(s => s.Cajero)
                    .HasConstraintName("cajero");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
