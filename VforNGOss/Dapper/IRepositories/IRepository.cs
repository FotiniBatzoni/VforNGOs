using VforNGOss.Dapper.Entities;
using VforNGOss.DataTransefObjects;

namespace VforNGOss.Repositories
{
    public interface IRepository
    {
        public Task Create(CreateDTO createDTO, int Id);

        public Task<IEnumerable<Item>> GetAll();

        public Task<Item> GetById(int id);

        public Task<IEnumerable<Item>> GetByUser(int id);

        public Task Update(UpdateDTO projectDTO, int id);

        public Task Delete(int id);
    }
}
