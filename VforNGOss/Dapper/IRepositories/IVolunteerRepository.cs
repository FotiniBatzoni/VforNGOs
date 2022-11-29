using VforNGOss.Models;

namespace VforNGOss.Dapper.Repositories
{
    public interface IVolunteerRepository
    {
        public Task<IEnumerable<Volunteer>> GetAll();

        public Task<Volunteer> GetById(int id);
    }
}
