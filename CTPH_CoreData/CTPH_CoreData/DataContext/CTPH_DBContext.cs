using System;
using CTPH_CoreData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CTPH_CoreData.DataContext
{
    public partial class CTPH_DBContext : DbContext
    {
        public CTPH_DBContext()
        {
        }

        public CTPH_DBContext(DbContextOptions<CTPH_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Elemento> Elementos { get; set; }
        public virtual DbSet<ElementosListasValore> ElementosListasValores { get; set; }
        public virtual DbSet<Muestra> Muestras { get; set; }
        public virtual DbSet<MuestrasValore> MuestrasValores { get; set; }
        public virtual DbSet<PuntosDeMedidum> PuntosDeMedida { get; set; }
        public virtual DbSet<SituacionAmbiente> SituacionAmbientes { get; set; }
        public virtual DbSet<SituacionAmbienteElemento> SituacionAmbienteElementos { get; set; }
        public virtual DbSet<TiposPuntosDeMedidum> TiposPuntosDeMedida { get; set; }
        public virtual DbSet<TiposValore> TiposValores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Elemento>(entity =>
            {
                entity.HasKey(e => e.IdElemento);

                entity.Property(e => e.IdElemento)
                    .ValueGeneratedNever()
                    .HasColumnName("idElemento");

                entity.Property(e => e.Elemento1)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Elemento");

                entity.Property(e => e.IdTipoValor).HasColumnName("idTipoValor");

                entity.HasOne(d => d.IdTipoValorNavigation)
                    .WithMany(p => p.Elementos)
                    .HasForeignKey(d => d.IdTipoValor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Elementos_Tipos_Valores");
            });

            modelBuilder.Entity<ElementosListasValore>(entity =>
            {
                entity.HasKey(e => e.IdListaValores);

                entity.ToTable("Elementos_Listas_Valores");

                entity.Property(e => e.IdListaValores).HasColumnName("idListaValores");

                entity.Property(e => e.IdElemento).HasColumnName("idElemento");

                entity.Property(e => e.NombreListaValor)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdElementoNavigation)
                    .WithMany(p => p.ElementosListasValores)
                    .HasForeignKey(d => d.IdElemento)
                    .HasConstraintName("FK_Elementos_Listas_Valores_Elementos");
            });

            modelBuilder.Entity<Muestra>(entity =>
            {
                entity.HasKey(e => e.IdMuestra);

                entity.Property(e => e.IdMuestra).HasColumnName("idMuestra");

                entity.Property(e => e.FhMuestra)
                    .HasColumnType("datetime")
                    .HasColumnName("fhMuestra")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdSituacionAmbiente).HasColumnName("idSituacionAmbiente");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSituacionAmbienteNavigation)
                    .WithMany(p => p.Muestras)
                    .HasForeignKey(d => d.IdSituacionAmbiente)
                    .HasConstraintName("FK_Muestras_SituacionAmbiente");
            });

            modelBuilder.Entity<MuestrasValore>(entity =>
            {
                entity.HasKey(e => new { e.IdMuestra, e.IdPuntoDeMedida });

                entity.ToTable("Muestras_Valores");

                entity.Property(e => e.IdMuestra).HasColumnName("idMuestra");

                entity.Property(e => e.IdPuntoDeMedida).HasColumnName("idPuntoDeMedida");

                entity.Property(e => e.Temperatura).HasColumnType("decimal(4, 2)");

                entity.HasOne(d => d.IdMuestraNavigation)
                    .WithMany(p => p.MuestrasValores)
                    .HasForeignKey(d => d.IdMuestra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Muestras_Valores_Muestras");

                entity.HasOne(d => d.IdPuntoDeMedidaNavigation)
                    .WithMany(p => p.MuestrasValores)
                    .HasForeignKey(d => d.IdPuntoDeMedida)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Muestras_Valores_PuntosDeMedida");
            });

            modelBuilder.Entity<PuntosDeMedidum>(entity =>
            {
                entity.HasKey(e => e.IdPuntoDeMedida);

                entity.Property(e => e.IdPuntoDeMedida).HasColumnName("idPuntoDeMedida");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipoPuntoDeMedida).HasColumnName("idTipoPuntoDeMedida");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(555)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoPuntoDeMedidaNavigation)
                    .WithMany(p => p.PuntosDeMedida)
                    .HasForeignKey(d => d.IdTipoPuntoDeMedida)
                    .HasConstraintName("FK_PuntosDeMedida_Tipos_PuntosDeMedida");
            });

            modelBuilder.Entity<SituacionAmbiente>(entity =>
            {
                entity.HasKey(e => e.IdSituacionAmbiente);

                entity.ToTable("SituacionAmbiente");

                entity.Property(e => e.IdSituacionAmbiente).HasColumnName("idSituacionAmbiente");

                entity.Property(e => e.Observaciones)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SituacionAmbienteElemento>(entity =>
            {
                entity.HasKey(e => e.IdSituacionAmbienteElementos);

                entity.ToTable("SituacionAmbiente_Elementos");

                entity.Property(e => e.IdSituacionAmbienteElementos).HasColumnName("idSituacionAmbienteElementos");

                entity.Property(e => e.IdElemento).HasColumnName("idElemento");

                entity.Property(e => e.IdListaValor).HasColumnName("idListaValor");

                entity.Property(e => e.IdSituacionAmbiente).HasColumnName("idSituacionAmbiente");

                entity.Property(e => e.Valor).HasMaxLength(255);

                entity.HasOne(d => d.IdElementoNavigation)
                    .WithMany(p => p.SituacionAmbienteElementos)
                    .HasForeignKey(d => d.IdElemento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SituacionAmbiente_Elementos_Elementos1");

                entity.HasOne(d => d.IdListaValorNavigation)
                    .WithMany(p => p.SituacionAmbienteElementos)
                    .HasForeignKey(d => d.IdListaValor)
                    .HasConstraintName("FK_SituacionAmbiente_Elementos_Elementos_Listas_Valores");

                entity.HasOne(d => d.IdSituacionAmbienteNavigation)
                    .WithMany(p => p.SituacionAmbienteElementos)
                    .HasForeignKey(d => d.IdSituacionAmbiente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SituacionAmbiente_Elementos_SituacionAmbiente1");
            });

            modelBuilder.Entity<TiposPuntosDeMedidum>(entity =>
            {
                entity.HasKey(e => e.IdTipoPuntoDeMedida);

                entity.ToTable("Tipos_PuntosDeMedida");

                entity.Property(e => e.IdTipoPuntoDeMedida).HasColumnName("idTipoPuntoDeMedida");

                entity.Property(e => e.Descripcion).HasMaxLength(55);
            });

            modelBuilder.Entity<TiposValore>(entity =>
            {
                entity.HasKey(e => e.IdTipoValor);

                entity.ToTable("Tipos_Valores");

                entity.Property(e => e.IdTipoValor).HasColumnName("idTipoValor");

                entity.Property(e => e.TipoValor)
                    .HasMaxLength(55)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
