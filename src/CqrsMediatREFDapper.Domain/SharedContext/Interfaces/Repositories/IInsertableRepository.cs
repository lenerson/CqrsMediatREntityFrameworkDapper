using System;
using System.Threading.Tasks;

namespace CqrsMediatREFDapper.Domain.SharedContext.Interfaces.Repositories
{
    public interface IInsertableRepository<TEntity> where TEntity : class
    {
        Task Add(TEntity entity);
    }
}
