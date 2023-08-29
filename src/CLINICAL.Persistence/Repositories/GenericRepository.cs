using CLINICAL.Application.Interface.Interface;
using CLINICAL.Persistence.Context;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string storeProcedure)
        {
            using var connection = _context.CreateConnection;
            return await connection.QueryAsync<T>(storeProcedure, commandType: CommandType.StoredProcedure);
        }

        public async Task<T> GetByIdAsync(string storeProcedure, object parameters)
        {
            using var connection = _context.CreateConnection;
            var objParameter = new DynamicParameters(parameters);
            return await connection.QuerySingleOrDefaultAsync<T>(storeProcedure, param: objParameter, commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> ExecuteAsync(string storeProcedure, object parameters)
        {
            using var connection = _context.CreateConnection;
            var objParameter = new DynamicParameters(parameters);
            var reccordAffected = await connection.ExecuteAsync(storeProcedure, param: objParameter, commandType: CommandType.StoredProcedure);
            return reccordAffected > 0;
        }
    }
}