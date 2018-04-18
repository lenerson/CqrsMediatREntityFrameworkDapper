using CqrsMediatREFDapper.Infra.CrossCutting.Util;
using CqrsMediatREFDapper.Infra.Data.Context.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CqrsMediatREFDapper.Infra.Data.Context
{
    public sealed class EFContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            RemoveConventions(modelBuilder);

            modelBuilder.ApplyConfiguration(new CourseMap());

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(Configuration.GetDefaultConnectionString());

        private void RemoveConventions(ModelBuilder modelBuilder)
        {
            #region Remove convention cascade delete

            var cascadeFKs = modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            #endregion
        }
    }
}
