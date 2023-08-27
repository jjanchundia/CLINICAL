using CLINICAL.Application.Interface;
using CLINICAL.Domain.Entities;
using CLINICAL.Persistence.Context;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Persistence.Repositories
{
    public class AnalisisRepository : IAnalisisRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public AnalisisRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<Analisis>> ListAnalisis()
        {
            //Cadena de conexión
            using var connection = _dbcontext.CreateConnection;
            
            //Store Procedure
            var query = "uspAnalisisList";

            var analisis = await connection.QueryAsync<Analisis>(query, CommandType.StoredProcedure);

            return analisis;
        }
    }
}