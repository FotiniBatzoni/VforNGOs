using VforNGOss.Models;

namespace VforNGOss.Dapper.IRepositories
{
    public interface IVolunteerRepository
    {
        public List<Volunteer> GetAll();

        public Volunteer FindById(Guid id);

        public Volunteer Create(Volunteer volunteer);

        public Volunteer Update(Volunteer volunteer);

        public Volunteer ForgotPassword(Volunteer volunteer);
        public void Remove(Guid id);
        // void Save(Volunteer volunteer);
    }
}


