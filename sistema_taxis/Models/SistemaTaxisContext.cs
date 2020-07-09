using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace sistema_taxis.Models
{
    public partial class SistemaTaxisContext : IdentityDbContext<Usuario>
    {
        private readonly string connectionString;
        public SistemaTaxisContext(string _connectionString)
        {
            connectionString = _connectionString;
        }

        public SistemaTaxisContext(DbContextOptions<SistemaTaxisContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chofer> Chofer { get; set; }
        public virtual DbSet<ChoferUnidad> ChoferUnidad { get; set; }
        public virtual DbSet<Pago> Pago { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<TipoSangre> TipoSangre { get; set; }
        public virtual DbSet<Unidad> Unidad { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Chofer>(entity =>
            {
                entity.Property(e => e.ChoferId).ValueGeneratedNever();

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Chofer)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Chofer_Status");

                entity.HasOne(d => d.TipoSangre)
                    .WithMany(p => p.Chofer)
                    .HasForeignKey(d => d.TipoSangreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Chofer_TipoSangre");
            });

            modelBuilder.Entity<ChoferUnidad>(entity =>
            {
                entity.HasKey(e => new { e.ChoferId, e.UnidadId });

                entity.HasOne(d => d.Chofer)
                    .WithMany(p => p.UnidadLink)
                    .HasForeignKey(d => d.ChoferId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_ChoferUnidad_Chofer");

                entity.HasOne(d => d.Unidad)
                    .WithMany(p => p.ChoferUnidad)
                    .HasForeignKey(d => d.UnidadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_ChoferUnidad_Unidad");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.Property(e => e.PagoId).ValueGeneratedNever();

                entity.Property(e => e.Cantidad).HasColumnType("money");

                entity.Property(e => e.FechaPago).HasColumnType("datetime");

                entity.Property(e => e.Usuario);

                entity.HasOne(d => d.Chofer)
                    .WithMany(p => p.PagoList)
                    .HasForeignKey(d => d.ChoferId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pago_Chofer");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TipoSangre>(entity =>
            {
                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(3);
            });

            modelBuilder.Entity<Unidad>(entity =>
            {
                entity.Property(e => e.UnidadId).ValueGeneratedNever();

                entity.Property(e => e.FinSeguro).HasColumnType("datetime");

                entity.Property(e => e.InicioSeguro).HasColumnType("datetime");

                entity.Property(e => e.Linea)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Nss)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.NumMotor)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.NumSerie)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.NumUnidad)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Vehiculo)
                    .IsRequired()
                    .HasMaxLength(45);

                //entity.HasOne(d => d.Chofer)
                //    .WithMany(p => p.UnidadList)
                //    .HasForeignKey(d => d.ChoferId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("Fk_Unidad_Chofer");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Unidad)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Unidad_Status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
