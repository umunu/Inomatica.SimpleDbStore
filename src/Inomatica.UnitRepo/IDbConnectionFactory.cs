using System.Data;

namespace Inomatica.UnitRepo
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
