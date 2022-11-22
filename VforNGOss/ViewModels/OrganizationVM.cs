using VforNGOss.Models;

namespace VforNGOss.ViewModels
{
    public class OrganizationVM
    {
        public OrganizationVM()
        {
            List<Organization> OrganizationList = new List<Organization>();
        }
        public List<Organization> OrganizationList { get; set; }
    }
}
