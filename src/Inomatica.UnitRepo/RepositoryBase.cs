namespace Inomatica.UnitRepo
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : IDbConnectionFactory
    {
        public IUnitOfWork<T> UnitOfWork { get; private set; }
        protected RepositoryBase(IUnitOfWork<T> uow)
        {
            UnitOfWork = uow;
        }
    }
}
