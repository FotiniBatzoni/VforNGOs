using VforNGOss.Models;

namespace VforNGOss.Repository
{
    public interface IOrganization
    {
        IList<Organization> GetOrganizations();
        Organization GetOrganizationById(int? id);
        void InsertNew(Organization organization);
        void Update(Organization organization);
        void Delete(Organization organization);

    }
}
