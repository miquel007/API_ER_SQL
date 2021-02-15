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

        public virtual DbSet<Pieza> Piezas { get; set; }
        public virtual DbSet<Proveedor> Proveedores { get; set; }
        public virtual DbSet<Suministra> Suministros { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Pieza>().HasKey(p => p.Codigo);
           modelBuilder.Entity<Pieza>( entity =>
            {
                entity.ToTable("Piezas");
                entity.Property(p => p.Codigo).HasColumnName("codigo");
                entity.Property(p => p.nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<Proveedor>().HasKey(p => p.ID);
            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.ToTable("Proveedores");
                entity.Property(p => p.ID).HasColumnName("id");
                entity.Property(p => p.nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Suministra>().HasKey(s => s.cod_pieza);
            modelBuilder.Entity<Suministra>().HasKey(s => s.id_proveedor);
            modelBuilder.Entity<Suministra>(entity =>
            {
                entity.ToTable("Suministra");
                entity.Property(s => s.cod_pieza).HasColumnName("cod_pieza");
                entity.Property(s => s.id_proveedor).HasColumnName("id_proveedor");
                entity.HasOne(s => s.piezas)
                    .WithMany(p => p.Proveedores)
                    .HasForeignKey(s => s.cod_pieza);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
