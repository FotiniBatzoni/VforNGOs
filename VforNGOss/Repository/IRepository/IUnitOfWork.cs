namespace VforNGOss.Repository.IRepository
{
    public interface IUnitOfWork
    {
        void Dispose();

        void SaveChanges();
    }
}
