using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace sistema_taxis.Models
{
    public partial class SistemaTaxisContext : DbContext
    {
        private readonly string _connectionString;
        public SistemaTaxisContext(string connectionString)
        {
            connectionString = _connectionString;
        }

        public SistemaTaxisContext(DbContextOptions<SistemaTaxisContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chofer> Chofer { get; set; }
        public virtual DbSet<Pago> Pago { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<TipoSangre> TipoSangre { get; set; }
        public virtual DbSet<Unidad> Unidad { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=SistemaTaxis;Trusted_Connection=True;");
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chofer>(entity =>
            {
                entity.Property(e => e.ChoferId).ValueGeneratedNever();

                entity.Property(e => e.Curp).IsRequired();

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Ine).IsRequired();

                entity.Property(e => e.Licencia).IsRequired();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Chofer)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Chofer__Status__412EB0B6");

                entity.HasOne(d => d.TipoSangreNavigation)
                    .WithMany(p => p.Chofer)
                    .HasForeignKey(d => d.TipoSangre)
                    .HasConstraintName("FK__Chofer__TipoSang__403A8C7D");

                entity.HasOne(d => d.UnidadNavigation)
                    .WithMany(p => p.Chofer)
                    .HasForeignKey(d => d.Unidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Chofer__Unidad__4222D4EF");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.Property(e => e.PagoId).ValueGeneratedNever();

                entity.Property(e => e.Cantidad).HasColumnType("money");

                entity.HasOne(d => d.ChoferNavigation)
                    .WithMany(p => p.Pago)
                    .HasForeignKey(d => d.Chofer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pago__Chofer__44FF419A");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TipoSangre>(entity =>
            {
                entity.HasKey(e => e.SangreId)
                    .HasName("PK__TipoSang__0A88EAEBAB689315");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(2);
            });

            modelBuilder.Entity<Unidad>(entity =>
            {
                entity.Property(e => e.UnidadId).ValueGeneratedNever();

                entity.Property(e => e.InicioSeguro).HasColumnType("datetime");

                entity.Property(e => e.Linea)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(100);

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

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Unidad)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Unidad__Status__3D5E1FD2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
