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
                var id = Guid.NewGuid();
                var sql =
                         "INSERT INTO Organizations ( Id, Email, Password) VALUES(@id, @Email, @Password)";
                organization.Id = id;
                connection.Execute(sql, organization);
             
                return organization;
            }

        }

        public Organization Update(Organization organization)
        {
            //Update Organizations
            //Set Email = 'org4@mail.com'
            //WHERE Id = 4;
            using (var connection = _context.CreateConnection())
            {
                var sql = $"UPDATE Organizations SET Email = @Email WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("@Email", organization.Email);
                parameters.Add("@Id", organization.Id);

                connection.Execute(sql, parameters);
                return organization;
            }
        }

        public void Remove(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                connection.Execute("DELETE FROM Organizations WHERE Id = @Id", new { id });
            }
                
        }
    }
}
