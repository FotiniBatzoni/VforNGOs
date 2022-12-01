using VforNGOss.Models;

namespace VforNGOss.Dapper.Repositories
{
    public interface IVolunteerRepository
    {
        // Volunteer Find(int id);

        public List<Volunteer> GetAll();

        // Volunteer Add(Volunteer volunteer);
        // Volunteer Update(Volunteer volunteer);
        // void Remove(int id);
        // void Save(Volunteer volunteer);
    }
}
