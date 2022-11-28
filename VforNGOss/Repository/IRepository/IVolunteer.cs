using VforNGOss.Models;

namespace VforNGOss.Repository
{
    public interface IVolunteer
    {
            IList<Volunteer> GetAll();
            Volunteer GetById(int? id);
            void InsertNew(Volunteer volunteer);
            void Update(Volunteer volunteer);
            void Delete(Volunteer volunteer);
        
    }
}
