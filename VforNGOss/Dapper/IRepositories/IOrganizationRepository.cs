using VforNGOss.Models;

namespace VforNGOss.Dapper.Repositories
{
    public interface IOrganizationRepository
    {
       // Organization Find(int id);

        public List<Organization> GetAll();

        public Organization Create(Organization organization);
       // Organization Update(Organization organization);
       // void Remove(int id);
       // void Save(Organization organization);

    }
}
