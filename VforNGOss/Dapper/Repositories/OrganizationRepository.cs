using Dapper;
using VforNGOss.DataAccessLayer.DatabaseConnectionDapper;
using VforNGOss.Models;

namespace VforNGOss.Dapper.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly DapperContext _context;
        public OrganizationRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Organization>> GetAll()
        {
            string sqlQuery = "SELECT * FROM Organizations";
            using (var connection = _context.CreateConnection())
            {
                var organizations = await connection.QueryAsync<Organization>(sqlQuery);
                return organizations.ToList();
            }
        }

        public async Task<Organization> GetById(int id)
        {
            string sqlQuery = "SELECT * FROM Organizations WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleAsync<Organization>(sqlQuery, new { Id = id });
            }
        }
    }
}
