namespace VforNGOss.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IList<T> GetAll();
        T GetById(int? id);
        void InsertNew(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
    }
}
