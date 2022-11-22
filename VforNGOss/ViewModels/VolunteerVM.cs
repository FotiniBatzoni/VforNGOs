using VforNGOss.Models;

namespace VforNGOss.ViewModels
{
    public class VolunteerVM
    {
        public VolunteerVM()
        {
            List<Volunteer> VolunteerList = new List<Volunteer>();
        }
        public List<Volunteer> VolunteerList { get; set; }
    }
}
