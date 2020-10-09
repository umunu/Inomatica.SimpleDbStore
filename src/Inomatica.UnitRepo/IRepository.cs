namespace Inomatica.UnitRepo
{
    public interface IRepository<T> where T : IDbConnectionFactory
    {
        IUnitOfWork<T> UnitOfWork { get; }
    }
}
