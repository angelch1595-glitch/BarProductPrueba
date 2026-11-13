using BackendBarProduc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace BackendBarProduc.Data
{
    public class UsuarioDbContext : IdentityDbContext<ApplicationUser>
    {
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options)
        : base(options)
        {
        }

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Proveedor> Proveedores => Set<Proveedor>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);   // NUEVA: siempre primero 
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(u => u.IdUsuario);
                entity.Property(u => u.Nombre).HasMaxLength(100);
                entity.Property(u => u.Apellido).HasMaxLength(100);
                entity.Property(u => u.Correo).HasMaxLength(100);
                entity.Property(u => u.Contraseña).HasMaxLength(255);
            });
            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.Property(p => p.Nombre).HasMaxLength(100);
                entity.Property(p => p.Telefono).HasMaxLength(20);
            });
        }
    }
}
