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
    }


    //public async Task<Volunteer> GetById(int id)
    //{
    //    string sqlQuery = "SELECT * FROM Organizations WHERE Id = @Id";
    //    using (var connection = _context.CreateConnection())
    //    {
    //        return await connection.QuerySingleAsync<Volunteer>(sqlQuery, new { Id = id });
    //    }
    //}
}


