using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CLINICAL.Persistence.Context
{
    public class ApplicationDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        //Inyectamos servicios.
        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ClinicalConnection")!; //! x asignación nula
        }

        //Nos ayudará a conectarnos a la BD
        public IDbConnection CreateConnection => new SqlConnection(_connectionString);
    }
}