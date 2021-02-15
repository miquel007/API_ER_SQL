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

        public virtual DbSet<Cientifico> Cientificos { get; set; }
        public virtual DbSet<Proyecto> Proyecto { get; set; }
        public virtual DbSet<Asignado_a> Asignado_A { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Cientifico>().HasKey(p => p.DNI);
           modelBuilder.Entity<Cientifico>( entity =>
            {
                entity.ToTable("Cientificos");
                entity.Property(p => p.DNI).HasColumnName("DNI");
                entity.Property(p => p.nomApels)
                    .HasColumnName("nomApels")
                    .HasMaxLength(255)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<Proyecto>().HasKey(p => p.ID);
            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.ToTable("Proyecto");
                entity.Property(p => p.ID).HasColumnName("id");
                entity.Property(p => p.nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(p => p.horas).HasColumnName("horas");
            });

            modelBuilder.Entity<Asignado_a>().HasKey(s => s.cientifico);
            modelBuilder.Entity<Asignado_a>().HasKey(s => s.proyecto);
            modelBuilder.Entity<Asignado_a>(entity =>
            {
                entity.ToTable("Asignado_A");
                entity.Property(s => s.cientifico).HasColumnName("cientifico");
                entity.Property(s => s.proyecto).HasColumnName("proyecto");
                entity.HasOne(s => s.cientificos)
                    .WithMany(p => p.Asignado_a)
                    .HasForeignKey(s => s.cientifico)
                    .HasConstraintName("cientifico");
                entity.HasOne(s => s.proyectos)
                    .WithMany(p => p.Asignado_a)
                    .HasForeignKey(s => s.proyecto)
                    .HasConstraintName("proyecto");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
