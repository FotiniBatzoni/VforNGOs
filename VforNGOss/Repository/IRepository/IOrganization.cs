using VforNGOss.Models;

namespace VforNGOss.Repository
{
    public interface IOrganization 
    {
        IList<Organization> GetAll();
        Organization GetById(int? id);
        void InsertNew(Organization organization);
        void Update(Organization organization);
        void Delete(Organization organization);

    }
}
