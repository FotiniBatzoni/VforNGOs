using Dapper;
//using VforNGOss.Dapper.IRepositories;
using VforNGOss.DataAccessLayer.DatabaseConnectionDapper;
using VforNGOss.Models;

namespace VforNGOss.Dapper.Repositories
{  
    
   // public class VolunteerRepository : IVolunteerRepository
    public class VolunteerRepository 
    {
        private readonly DapperContext _context;
        public VolunteerRepository(DapperContext context)
        {
            _context = context;
        }

        public List<Volunteer> GetAll()
        {
            string sqlQuery = "SELECT * FROM Volunteers";
            using (var connection = _context.CreateConnection())
            {
                var volunteers = connection.Query<Volunteer>(sqlQuery).ToList();
                return volunteers;
            }
        }


        public Volunteer FindById(Guid id)
        {
            using (var connection = _context.CreateConnection())
            {
                return connection.Query<Volunteer>("SELECT * FROM Volunteers WHERE Id = @Id", new { id }).FirstOrDefault();
            }

        }

        public Volunteer Create(Volunteer volunteer)
        {
            using (var connection = _context.CreateConnection())
            {
                string hashedPassword = SecurePasswordHasher.HashPassword(volunteer.Password);
                volunteer.Password = hashedPassword;

                var id = Guid.NewGuid();
                var sql =
                         "INSERT INTO Volunteers ( Id, Email, Password) VALUES(@id, @Email, @Password)";
                volunteer.Id = id;
                connection.Execute(sql, volunteer);

                return volunteer;
            }

        }

        public Volunteer ForgotPassword(Volunteer volunteer)
        {
            using (var connection = _context.CreateConnection())
            {
                var volunteerDb = connection.Query<Volunteer>("SELECT * FROM Volunteers WHERE Email = @Email", new { volunteer.Email }).FirstOrDefault();

                if (volunteerDb is null)
                {
                    return null;
                }

                string newPassword = volunteer.Password;

                string hashedPassword = SecurePasswordHasher.HashPassword(newPassword);
                volunteer.Password = hashedPassword;

                var sql = $"UPDATE Volunteers SET Password = @Password WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("@Password", volunteer.Password);
                parameters.Add("@Id", volunteerDb.Id);

                connection.Execute(sql, parameters);
                return volunteer;
            }

        }

        public Volunteer Update(Volunteer volunteer)
        {
            using (var connection = _context.CreateConnection())
            {
                var sql = $"UPDATE Volunteers SET Email = @Email WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("@Email", volunteer.Email);
                parameters.Add("@Id", volunteer.Id);

                connection.Execute(sql, parameters);
                return volunteer;
            }
        }


        public void Remove(Guid id)
        {
            using (var connection = _context.CreateConnection())
            {
                connection.Execute("DELETE FROM Volunteers WHERE Id = @Id", new { id });
            }

        }
    }

}


