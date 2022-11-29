using VforNGOss.Models;

namespace VforNGOss.Dapper.Repositories
{
    public interface IOrganizationRepository
    {
        public Task<IEnumerable<Organization>> GetAll();

        public Task<Organization> GetById(int id);
    }
}
