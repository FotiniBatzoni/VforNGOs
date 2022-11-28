namespace VforNGOss.Repository.IRepository
{
    public interface IRepository <T> where T : class
    {
        IList<T> GetAll();
        T GetById(int? id);
        void InsertNew(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
