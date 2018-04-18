using System;
using System.Threading.Tasks;

namespace CqrsMediatREFDapper.Domain.SharedContext.Interfaces.Repositories
{
    public interface IRemovableRepository<TEntity> where TEntity : class
    {
        Task Remove(Guid id);
    }
}
