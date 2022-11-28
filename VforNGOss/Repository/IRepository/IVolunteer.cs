using VforNGOss.Models;

namespace VforNGOss.Repository
{
    public interface IVolunteer
    {
        IList<Volunteer> GetVolunteers();
        Volunteer GetVolunteerById(int? id);
        void InsertNew(Volunteer volunteer);
        void Update(Volunteer volunteer);
        void Delete(Volunteer volunteer);

    }
}
