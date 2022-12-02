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

        public Organization FindById(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                return connection.Query<Organization>("SELECT * FROM Organizations WHERE Id = @Id", new { id }).SingleOrDefault();
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

        public Organization Update(Organization organization)
        {
            var connection = _context.CreateConnection();
            connection.Execute("UPDATE Addresses " +
                "SET Email = @Email, " +
                "WHERE Id = @Id", organization);
            return organization;
        }
    }
}
