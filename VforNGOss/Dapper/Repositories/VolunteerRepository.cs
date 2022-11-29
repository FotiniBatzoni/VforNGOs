using Dapper;
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
        public async Task<IEnumerable<Volunteer>> GetAll()
        {
            string sqlQuery = "SELECT * FROM Volunteers";
            using (var connection = _context.CreateConnection())
            {
                var organizations = await connection.QueryAsync<Volunteer>(sqlQuery);
                return organizations.ToList();
            }
        }

        public async Task<Volunteer> GetById(int id)
        {
            string sqlQuery = "SELECT * FROM Organizations WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleAsync<Volunteer>(sqlQuery, new { Id = id });
            }
        }
    }

}
