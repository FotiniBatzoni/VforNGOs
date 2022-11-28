using VforNGOss.Models;
using VforNGOss.Repository.IRepository;

namespace VforNGOss.Repository
{
    public interface IVolunteer : IRepository<Volunteer>
    {
            IList<Volunteer> GetAll();
            Volunteer GetById(int? id);
            void InsertNew(Volunteer volunteer);
            void Update(Volunteer volunteer);
            void Delete(Volunteer volunteer);
        
    }
}
