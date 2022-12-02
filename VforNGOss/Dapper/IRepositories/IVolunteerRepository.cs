using VforNGOss.Models;

namespace VforNGOss.Dapper.IRepositories
{
    public interface IVolunteerRepository
    {
        public List<Volunteer> GetAll();

        public Volunteer FindById(int id);

        public Volunteer Create(Volunteer volunteer);

        public  Volunteer Update(Volunteer volunteer);
        public void Remove(int id);
        // void Save(Volunteer volunteer);
    }
}


