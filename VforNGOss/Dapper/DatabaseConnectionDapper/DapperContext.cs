using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace VforNGOss.DataAccessLayer.DatabaseConnectionDapper
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
   
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

    }
}
