using VforNGOss.Models;
using VforNGOss.Repository.IRepository;

namespace VforNGOss.Repository
{
    public interface IOrganization : IRepository<Organization>
    {
        IList<Organization> GetAll();
        Organization GetById(int? id);
        void InsertNew(Organization organization);
        void Update(Organization organization);
        void Delete(Organization organization);

    }
}
