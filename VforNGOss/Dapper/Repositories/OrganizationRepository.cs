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

        public List<Organization> GetAll()
        {
            string sqlQuery = "SELECT * FROM Organizations";
            using (var connection = _context.CreateConnection())
            {
                var organizations =  connection.Query<Organization>(sqlQuery).ToList();
                return organizations;
            }
        }


        public Organization Create(Organization organization)
        {
            using (var connection = _context.CreateConnection())
            {
                var sql =
                         "INSERT INTO Organizations (Email) VALUES(@Email); " +
                          "SELECT CAST(SCOPE_IDENTITY() as int)";
                var id = connection.Query<int>(sql, organization).Single();
                organization.Id = id;
                return organization;
            }


        }
    }
}
