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

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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
            var deletedItems = ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted && e.Metadata.GetProperties().Any(x => x.Name == "IsDeleted"));

            foreach (var item in createdItems)
            {
                item.CurrentValues["CreatedAt"] = DateTime.Now;
                item.CurrentValues["UpdatedAt"] = DateTime.Now;
            }

            foreach (var item in updatedItems)
            {
                item.CurrentValues["CreatedAt"] = item.OriginalValues["CreatedAt"];
                item.CurrentValues["UpdatedAt"] = DateTime.Now;
            }

            foreach (var item in deletedItems)
            {
                item.State = EntityState.Unchanged;
                item.CurrentValues["DeletedAt"] = DateTime.Now;
            }
        }
    }
}
