using Microsoft.EntityFrameworkCore;
using SOE_MDEIS_BACKEND_GESTION.Models;



namespace SOE_MDEIS_BACKEND_GESTION.Data
{
    public class ApplicationDbContext : DbContext
    {   
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Cliente> Clientes { get; set; } = null!;
        public DbSet<Empleado> Productos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Producto
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");
                entity.HasKey(e => e.ProductoId);

                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsRequired();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500);

                entity.Property(e => e.Categoria)
                    .HasMaxLength(100);

                entity.Property(e => e.PrecioUnitario)
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.Activo)
                    .HasDefaultValue(true);
            });

            // Cliente
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");
                entity.HasKey(e => e.ClienteId);

                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(20)
                    .IsRequired();

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(30)
                    .IsRequired();

                entity.Property(e => e.Nombres)
                    .HasMaxLength(150)
                    .IsRequired();

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(150)
                    .IsRequired();

                entity.Property(e => e.Email)
                    .HasMaxLength(200);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(250);

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.Activo)
                    .HasDefaultValue(true);
            });

            // Empleado
            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("Empleado");
                entity.HasKey(e => e.EmpleadoId);

                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(20)
                    .IsRequired();

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(30)
                    .IsRequired();

                entity.Property(e => e.Nombres)
                    .HasMaxLength(150)
                    .IsRequired();

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(150)
                    .IsRequired();

                entity.Property(e => e.Cargo)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.Email)
                    .HasMaxLength(200);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50);

                entity.Property(e => e.FechaContratacion)
                    .HasColumnType("date");

                entity.Property(e => e.SalarioMensual)
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.Activo)
                    .HasDefaultValue(true);
            });
        }

    }
}
