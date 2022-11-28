namespace VforNGOss.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IOrganization Organization { get; }
        IVolunteer Volunteer { get; }

        void Save();
    }
}
