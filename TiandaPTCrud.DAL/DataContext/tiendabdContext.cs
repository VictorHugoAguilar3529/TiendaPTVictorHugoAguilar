using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TiandaPTCrud.Models;

namespace TiandaPTCrud.DAL.DataContext
{
    public partial class tiendabdContext : DbContext
    {
        public tiendabdContext()
        {
        }

        public tiendabdContext(DbContextOptions<tiendabdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artículo> Artículos { get; set; } = null!;
        public virtual DbSet<ArtículoTiendum> ArtículoTienda { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<ClienteArtículo> ClienteArtículos { get; set; } = null!;
        public virtual DbSet<Tiendum> Tienda { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artículo>(entity =>
            {
                entity.Property(e => e.ArtículoId).HasColumnName("ArtículoID");

                entity.Property(e => e.Código)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripción).HasColumnType("text");

                entity.Property(e => e.Imagen)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<ArtículoTiendum>(entity =>
            {
                entity.HasKey(e => new { e.ArtículoId, e.TiendaId })
                    .HasName("PK__Artículo__89770350ADDBD969");

                entity.ToTable("Artículo_Tienda");

                entity.Property(e => e.ArtículoId).HasColumnName("ArtículoID");

                entity.Property(e => e.TiendaId).HasColumnName("TiendaID");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.HasOne(d => d.Artículo)
                    .WithMany(p => p.ArtículoTienda)
                    .HasForeignKey(d => d.ArtículoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Artículo___Artíc__164452B1");

                entity.HasOne(d => d.Tienda)
                    .WithMany(p => p.ArtículoTienda)
                    .HasForeignKey(d => d.TiendaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Artículo___Tiend__173876EA");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.ClienteId).HasColumnName("ClienteID");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Dirección)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClienteArtículo>(entity =>
            {
                entity.HasKey(e => new { e.ClienteId, e.ArtículoId })
                    .HasName("PK__Cliente___44C0245687D38FE7");

                entity.ToTable("Cliente_Artículo");

                entity.Property(e => e.ClienteId).HasColumnName("ClienteID");

                entity.Property(e => e.ArtículoId).HasColumnName("ArtículoID");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.HasOne(d => d.Artículo)
                    .WithMany(p => p.ClienteArtículos)
                    .HasForeignKey(d => d.ArtículoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cliente_A__Artíc__1B0907CE");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.ClienteArtículos)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cliente_A__Clien__1A14E395");
            });

            modelBuilder.Entity<Tiendum>(entity =>
            {
                entity.HasKey(e => e.TiendaId)
                    .HasName("PK__Tienda__FC84C42CF1D040B5");

                entity.Property(e => e.TiendaId).HasColumnName("TiendaID");

                entity.Property(e => e.Dirección)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Sucursal)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
