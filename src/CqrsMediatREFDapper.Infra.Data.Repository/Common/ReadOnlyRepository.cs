using CqrsMediatREFDapper.Domain.SharedContext.Interfaces.Repositories;
using CqrsMediatREFDapper.Infra.CrossCutting.Util;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CqrsMediatREFDapper.Infra.Data.Repository.Common
{
    public abstract class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class
    {
        public async Task<TEntity> GetById(Guid id)
        {
            using (var connection = GetConnection())
                return await connection.GetAsync<TEntity>(id);
        }
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            using (var connection = GetConnection())
                return await connection.GetAllAsync<TEntity>();
        }
        protected SqlConnection GetConnection()
        {
            var connection = new SqlConnection(Configuration.GetDefaultConnectionString());
            connection.Open();
            return connection;
        }
    }
}
