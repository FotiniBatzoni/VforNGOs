using Dapper;
using VforNGOss.Dapper.IRepositories;
using VforNGOss.DataAccessLayer.DatabaseConnectionDapper;
using VforNGOss.Models;

namespace VforNGOss.Dapper.Repositories
{
    public class VolunteerRepository : IVolunteerRepository
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


        public Volunteer FindById(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                return connection.Query<Volunteer>("SELECT * FROM Volunteers WHERE Id = @Id", new { id }).SingleOrDefault();
            }

        }

        public Volunteer Create(Volunteer volunteer)
        {
            using (var connection = _context.CreateConnection())
            {
                var id = Guid.NewGuid();
                var sql =
                         "INSERT INTO Volunteers ( Id, Email, Password) VALUES(@id, @Email, @Password)";
                volunteer.Id = id;
                connection.Execute(sql, volunteer);

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


        public void Remove(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                connection.Execute("DELETE FROM Volunteers WHERE Id = @Id", new { id });
            }

        }
    }

}


