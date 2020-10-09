using System.Data;

namespace Inomatica.UnitRepo
{
    public interface IUnitOfWork<T> where T : IDbConnectionFactory
    {
        void UseTransaction();
        IDbConnection UseConnection();
        void Commit();
        void Rollback();
    }
}
