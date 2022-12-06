using Dapper;
using VforNGOss.DataAccessLayer.DatabaseConnectionDapper;
using VforNGOss.Models;
using VforNGOss.Utilities;


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

        public Organization FindById(Guid id)
        {
            using (var connection = _context.CreateConnection())
            {
                return connection.Query<Organization>("SELECT * FROM Organizations WHERE Id = @Id", new { id }).FirstOrDefault();
            }
            
        }

        public Organization Create(Organization organization)
        {
            using (var connection = _context.CreateConnection())
            {
                
                string hashedPassword = SecurePasswordHasher.HashPassword(organization.Password);
                organization.Password = hashedPassword;
                var id = Guid.NewGuid();
                var sql =
                         "INSERT INTO Organizations ( Id, Email, Password) VALUES(@id, @Email, @Password)";

                organization.Id = id;
                connection.Execute(sql, organization);
             
                return organization;
            }

        }

        public Organization ForgotPassword(Organization organization)
        {
            using (var connection = _context.CreateConnection())
            {
                var organizationDb = connection.Query<Organization>("SELECT * FROM Organizations WHERE Email = @Email", new { organization.Email }).FirstOrDefault();

                if (organizationDb is null)
                {
                    return null;
                }

                string newPassword = organization.Password;

                string hashedPassword = SecurePasswordHasher.HashPassword(newPassword);
                organization.Password = hashedPassword;


                var sql = $"UPDATE Organizations SET Password = @Password WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("@Password", organization.Password);
                parameters.Add("@Id",organizationDb.Id);

                connection.Execute(sql, parameters);
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
                var sql = $"UPDATE Organizations SET Email = @Email, Password=@Password WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("@Email", organization.Email);
                parameters.Add("@Id", organization.Id);
                parameters.Add("@Password", organization.Password);

                connection.Execute(sql, parameters);
                return organization;
            }
        }

        public void Remove(Guid id)
        {
            using (var connection = _context.CreateConnection())
            {
                connection.Execute("DELETE FROM Organizations WHERE Id = @Id", new { id });
            }
                
        }
    }
}
