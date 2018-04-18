using CqrsMediatREFDapper.Domain.SharedContext.Interfaces.Repositories;
using CqrsMediatREFDapper.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CqrsMediatREFDapper.Infra.Data.Repository.Common
{
    public abstract class WriteOnlyRepository<TEntity> :
        IInsertableRepository<TEntity>,
        IUpdatableRepository<TEntity>,
        IRemovableRepository<TEntity> where TEntity : class
    {
        private readonly EFContext context;
        private readonly DbSet<TEntity> dbSet;

        protected WriteOnlyRepository()
        {
            context = new EFContext();
            dbSet = context.Set<TEntity>();
        }
        public async Task Add(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            await context.SaveChangesAsync();
        }
        public async Task Update(TEntity entity)
        {
            dbSet.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task Remove(Guid id)
        {
            dbSet.Remove(await dbSet.FindAsync(id));
            await context.SaveChangesAsync();
        }
    }
}
