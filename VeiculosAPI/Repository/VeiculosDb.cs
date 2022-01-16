using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VeiculosAPI.Repository.Models;

namespace VeiculosAPI.Repository
{
    public class VeiculosDb : DbContext
    {
        public VeiculosDb(DbContextOptions<VeiculosDb> options) : base(options) { }

        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<Modelo> Modelos { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<Permissao> Permissoes { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Marca>().HasMany(c => c.Modelos).WithOne(c => c.Marca).HasForeignKey(c => c.MarcaId);
        }

        public override int SaveChanges()
        {
            UpdateData();

            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            UpdateData();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateData();

            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            UpdateData();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateData()
        {
            var createdItems = ChangeTracker.Entries().Where(e => e.State == EntityState.Added && e.Metadata.GetProperties().Any(x => x.Name == "CreatedAt") && e.Metadata.GetProperties().Any(x => x.Name == "UpdatedAt"));
            var updatedItems = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified && e.Metadata.GetProperties().Any(x => x.Name == "CreatedAt") && e.Metadata.GetProperties().Any(x => x.Name == "UpdatedAt"));
            var deletedItems = ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted && e.Metadata.GetProperties().Any(x => x.Name == "DeletedAt"));

            var now = DateTime.Now;

            foreach (var item in createdItems)
            {
                item.CurrentValues["CreatedAt"] = now;
                item.CurrentValues["UpdatedAt"] = now;
            }

            foreach (var item in updatedItems)
            {
                item.CurrentValues["CreatedAt"] = item.OriginalValues["CreatedAt"];
                item.CurrentValues["UpdatedAt"] = now;
            }

            foreach (var item in deletedItems)
            {
                item.State = EntityState.Unchanged;
                item.CurrentValues["DeletedAt"] = now;
            }
        }
    }
}
