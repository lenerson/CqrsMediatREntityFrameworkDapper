using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CqrsMediatREFDapper.Domain.SharedContext.Interfaces.Repositories
{
    public interface IReadOnlyRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
    }
}
