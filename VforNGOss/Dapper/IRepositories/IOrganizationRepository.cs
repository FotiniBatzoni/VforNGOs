using VforNGOss.Models;

namespace VforNGOss.Dapper.Repositories
{
    public interface IOrganizationRepository
    {
        public List<Organization> GetAll();

       public Organization FindById(int id);

        public Organization Create(Organization organization);

        public Organization Update(Organization organization);

       // void Remove(int id);
       // void Save(Organization organization);

    }
}
