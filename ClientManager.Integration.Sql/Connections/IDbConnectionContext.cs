using System.Data;

namespace ClientManager.Integration.Sql.Connections
{
    public interface IDbConnectionContext
    {
        IDbConnection GetConnection();
        IDbTransaction GetTransaction();
        void Commit();
        void Rollback();
    }
}