namespace VforNGOss.Repository.IRepository
{
    public interface IConnectionFactory
    {
        IDbConnection Create();
    }
}
