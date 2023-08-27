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
        
        public async Task<Analisis> AnalisisById(int id)
        {
            //Cadena de conexión
            using var connection = _dbcontext.CreateConnection;

            //Store Procedure
            var query = "uspAnalisisById";

            //Parametros de entrada
            var parameters = new DynamicParameters();
            parameters.Add("AnalisisId", id);

            var analisis = await connection.QuerySingleOrDefaultAsync<Analisis>(query, param: parameters, commandType: CommandType.StoredProcedure);

            return analisis;
        }
    }
}