using Dapper;
using System.Data;
using VforNGOss.Dapper.Entities;
using VforNGOss.DataAccessLayer.DatabaseConnectionDapper;
using VforNGOss.DataTransefObjects;
using VforNGOss.Repositories;

namespace VforNGOss.Dapper.Repositories
{
    public class Repository : IRepository
    {
        private readonly DapperContext _context;
        public Repository(DapperContext context)
        {
            _context = context;
        }


        public async Task Create(CreateDTO createDTO, int Id)
        {
            string sqlQuery = "INSERT into Todos (Id, Email) values (@Id,  @Email)";
            var parameters = new DynamicParameters();
            parameters.Add("Id", createDTO.Id, DbType.Int64);
            parameters.Add("Email", createDTO.Email, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var r = await connection.ExecuteAsync(sqlQuery, parameters);
            }
        }


        public async Task Update(UpdateDTO projectDTO, int id)
        {
            string sqlQuery = "UPDATE Todos SET Id = @Id, Email = @Email WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Email", projectDTO.Email, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(sqlQuery, parameters);
            }
        }

        public async Task<IEnumerable<Item>> GetAll()
        {
            string sqlQuery = "SELECT * FROM Todos";
            using (var connection = _context.CreateConnection())
            {
                var todos = await connection.QueryAsync<Item>(sqlQuery);
                return todos.ToList();
            }
        }


        public async Task<Item> GetById(int id)
        {
            string sqlQuery = "SELECT * FROM Todos WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                var todo = await connection.QuerySingleAsync<Item>(sqlQuery, new { Id = id });
                return todo;
            }
        }

        public async Task<IEnumerable<Item>> GetByUser(int id)
        {
            string sqlQuery = "SELECT * FROM Todos WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                IEnumerable<Item> todos = await connection.QueryAsync<Item>(sqlQuery, new { Id = id });
                return todos;
            }
        }


        public async Task Delete(int id)
        {
            string query = "DELETE FROM Todos WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }






    }
}
