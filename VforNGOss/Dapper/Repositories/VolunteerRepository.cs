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
                var volunteers =  connection.Query<Volunteer>(sqlQuery).ToList();
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
                var sql =
                         "INSERT INTO Volunteers (Email) VALUES(@Email); " +
                          "SELECT CAST(SCOPE_IDENTITY() as int)";
                var id = connection.Query<int>(sql, volunteer).Single();
                volunteer.Id = id;
                return volunteer;
            }

        }
    }



}


